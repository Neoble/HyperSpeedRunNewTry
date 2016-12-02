using UnityEngine;
using System.Collections;

public class SpeedUp : MonoBehaviour
{
    public MotherCollider colliders;
    public AudioManager audioContainer;
    private AudioSource SoundsourceSeedUp;
    [SerializeField]
    public float newSpeed;
    private bool collided;

    void Start()
    {
        colliders = GetComponent<MotherCollider>();
        colliders.Collision += SpeedUP_Collision;
        SoundsourceSeedUp = GetComponent<AudioSource>();
    }

    private void SpeedUP_Collision(MotherCollider obj)
    {
        if (obj.gameObject.tag == "Player")
        {
            collided = false;
            obj.GetComponent<SphereMovement>().speed = newSpeed;
            if (!collided)
            {
                if (!SoundsourceSeedUp.isPlaying)
                {
                    SoundsourceSeedUp.PlayOneShot(audioContainer.au_faster);
                    collided = true;
                }
            }
        }
    }

    void Update()
    {

    }

}
