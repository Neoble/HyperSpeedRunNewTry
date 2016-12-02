using UnityEngine;
using System.Collections;

public class SpeedDown : MonoBehaviour
{
    MotherCollider colliders;
    public AudioManager audioContainer;
    private AudioSource SoundsourceSpeedDown;
    [SerializeField]
    public float newSpeed;
    private bool collided;

    void Start()
    {
        colliders = GetComponent<MotherCollider>();
        colliders.Collision += SpeedDown_Collision;
        SoundsourceSpeedDown = GetComponent<AudioSource>();
    }

    private void SpeedDown_Collision(MotherCollider obj)
    {
        if (obj.gameObject.tag == ("Player"))
        {
            collided = false;
            obj.GetComponent<SphereMovement>().speed = newSpeed;


        }
    }
    void Update()
    {

    }
}
