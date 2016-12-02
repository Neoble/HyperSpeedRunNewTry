using UnityEngine;
using System.Collections;

public class SphereMovement : MonoBehaviour
{
    Vector3D UpdatePosition;
    MotherCollider colliders;
    Vector3D StartVector;

    [SerializeField]
    public float fallingSpeed;
    [SerializeField]
    public float speed;
    public float timer;

    void Start()
    {
        StartVector = new Vector3D(0, 2, -5);
        colliders = GetComponent<MotherCollider>();
        gameObject.transform.position = StartVector;
        timer = 0f;
        speed = 12.0f;
    }

    void Update()
    {
        if (StarCountDown.play)
        {
            if (colliders.grounded)
            {
                fallingSpeed = 0;
            }
            else
            {
                fallingSpeed = -4;
            }
            GetComponent<Jump>().DoJump();

            this.gameObject.transform.position = Vector3D.Falling(this.gameObject, fallingSpeed);

            UpdatePosition = Vector3D.Position(this.gameObject);
            this.transform.position = StartVector.Translate(new Vector3D(UpdatePosition.x, UpdatePosition.y, (this.gameObject.transform.position.z + speed * Time.deltaTime)));
        }
    }


}
