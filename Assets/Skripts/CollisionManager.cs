using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CollisionManager : MonoBehaviour
{
    CollisionManager()
    {

    }

    public List<MotherCollider> Collisionboxes = new List<MotherCollider>();
    public List<MotherCollider> RemovedColliders = new List<MotherCollider>();
    public List<MotherCollider> AddedColliders = new List<MotherCollider>();
    public GameObject Sphere;
    public static float distance;
    public float distance2;

    void Update()
    {
        distance2 = distance;
        Collisionboxes.AddRange(AddedColliders);
        AddedColliders.Clear();
        var dynamicColliders = Collisionboxes.FindAll(x => x.dynamic);
        foreach (var item in dynamicColliders)
        {
            item.grounded = false;
            foreach (var other in Collisionboxes)
            {
                if (item == other)
                {
                    continue;
                }
                bool colliding = false;
                if (item is SphereCollider && other is SphereCollider)
                {
                    colliding = HandleCollision((SphereCollider)item, (SphereCollider)other);
                }
                else if (item is BoxCollider && other is BoxCollider)
                {
                    colliding = HandleCollision((BoxCollider)item, (BoxCollider)other);
                }
                else if (item is SphereCollider && other is BoxCollider)
                {
                    colliding = HandleCollision((SphereCollider)item, (BoxCollider)other);
                }
                else if (item is BoxCollider && other is SphereCollider)
                {
                    colliding = HandleCollision((SphereCollider)other, (BoxCollider)item);
                }

                if (colliding)
                {
                    item.OnCollision(other);
                    other.OnCollision(item);
                }
            }
        }
        foreach (var item in RemovedColliders)
        {
            Collisionboxes.Remove(item);
            Destroy(item.gameObject,2f);
        }
        RemovedColliders.Clear();
    }

    private static bool HandleCollision(SphereCollider ColliderA, SphereCollider ColliderB)
    {
        return (ColliderA.WorldCenter - ColliderB.WorldCenter).Magnitude() < ColliderA.SphereRadius + ColliderB.SphereRadius;
    }
    private static bool HandleCollision(SphereCollider ColliderA, BoxCollider ColliderB)
    {
        float distanceX;
        float distanceY;
        float distanceZ;
        //closest Point to sphere center
        distanceX = Mathf.Max(ColliderB.WorldLeft, Mathf.Min(ColliderA.WorldCenter.x, ColliderB.WorldRight));
        distanceY = Mathf.Max(ColliderB.WorldBottom, Mathf.Min(ColliderA.WorldCenter.y, ColliderB.WorldTop));
        distanceZ = Mathf.Max(ColliderB.WorldFront, Mathf.Min(ColliderA.WorldCenter.z, ColliderB.WorldBack));

        distance = Mathf.Sqrt((distanceX - ColliderA.WorldCenter.x) * (distanceX - ColliderA.WorldCenter.x) + (distanceY - ColliderA.WorldCenter.y) * (distanceY - ColliderA.WorldCenter.y) + (distanceZ - ColliderA.WorldCenter.z) * (distanceZ - ColliderA.WorldCenter.z));
        ColliderB.distance = distance;

        return distance < ColliderA.SphereRadius;
    }

    private static bool HandleCollision(BoxCollider ColliderA, BoxCollider ColliderB)
    {
        return ColliderA.WorldLeft <= ColliderB.WorldRight && ColliderA.WorldRight >= ColliderB.WorldLeft && ColliderA.WorldBottom <= ColliderB.WorldTop && ColliderA.WorldTop >= ColliderB.WorldBottom && ColliderA.WorldFront <= ColliderB.WorldBack && ColliderA.WorldBack >= ColliderB.WorldFront;
    }

}
