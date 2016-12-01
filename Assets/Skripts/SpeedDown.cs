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

    // Use this for initialization
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
            if (!collided)
            {
                if (!SoundsourceSpeedDown.isPlaying)
                {
                    SoundsourceSpeedDown.PlayOneShot(audioContainer.au_slower);
                    collided = true;
                }
            }

        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
