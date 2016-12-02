using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour
{
    public MotherCollider colliders;
    public SphereMovement obj;
    public AudioManager AudioContainer;
    private AudioSource SoundsourceJump;
    private float timer;
    private bool isJumping;

    void Start()
    {
        colliders = GetComponent<MotherCollider>();
        colliders.Collision += Jump_Collision;
        isJumping = false;
        SoundsourceJump = GetComponent<AudioSource>();
    }

    private void Jump_Collision(MotherCollider obj)
    {
        if (obj.gameObject.tag == "jump" && !isJumping)
        {
            timer = 0;
            colliders.grounded = false;
            obj.GetComponent<Animator>().SetTrigger("istriggered");
            isJumping = true;
            SoundsourceJump.PlayOneShot(AudioContainer.au_jump);

        }
    }
    public void DoJump()
    {
        if (isJumping == true)
        {
            timer += Time.deltaTime;
            if (timer < 0.3f)
            {
                colliders.grounded = false;
                obj.fallingSpeed = 6;
            }
            else
            {
                isJumping = false;
            }
        }
    }
}


