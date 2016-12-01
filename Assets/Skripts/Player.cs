using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    MotherCollider colliders;
    public AudioManager audioContainer;
    private AudioSource SoundsourceSphere;
    private bool died;
    private bool collided;
    private float timer;

    // Use this for initialization
    void Start()
    {
        colliders = GetComponent<MotherCollider>();
        colliders.Collision += Player_Collision;
        SoundsourceSphere = GetComponent<AudioSource>();
        SoundsourceSphere.clip = audioContainer.au_backbeat;
        SoundsourceSphere.Play();
        died = false;
        collided = false;
        timer = 0;
    }

    private void Player_Collision(MotherCollider obj)
    {
        if (obj.gameObject.layer == 8)
        {
            colliders.grounded = true;
        }
        else
        {
           
            if (!collided)
            {
                SoundsourceSphere.PlayOneShot(audioContainer.au_collision);
                collided = true;
            }
            this.gameObject.GetComponent<SphereMovement>().speed = 0;
            this.gameObject.GetComponent<Movement>().moveSpeedLeft = 0;
            this.gameObject.GetComponent<Movement>().touchspeed = 0;
            this.gameObject.GetComponent<Movement>().moveSpeedRight = 0;
            timer += Time.deltaTime;
            if (timer > 0.6f)
            {
                colliders.enabled = false;
                StarCountDown.play = false;
                SceneManager.LoadScene("LooseScene");
            }
        }
        if (obj.gameObject.tag=="Finish")
        {
            if (!collided)
            {
                SoundsourceSphere.PlayOneShot(audioContainer.au_victory);
                collided = true;
            }
            this.gameObject.GetComponent<SphereMovement>().speed = 0;
            this.gameObject.GetComponent<Movement>().moveSpeedLeft = 0;
            this.gameObject.GetComponent<Movement>().moveSpeedRight = 0;
            this.gameObject.GetComponent<Movement>().touchspeed = 0;
            timer += Time.deltaTime;
            if (timer > 0.6f)
            {
                StarCountDown.play = false;
                SceneManager.LoadScene("WinScene");
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
      
        if (this.gameObject.transform.position.y < -1)
        {
            if (!died)
            {
                SoundsourceSphere.PlayOneShot(audioContainer.au_falling[Random.Range(0, audioContainer.au_falling.Length)], 1);
                died = true;
            }
        }
        if (this.gameObject.transform.position.y < -10)
        {
            colliders.enabled = false;
            StarCountDown.play = false;
            SceneManager.LoadScene("LooseScene");
        }
    }
}
