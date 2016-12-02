using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{

    [SerializeField]
    public float fallingSpeed;
    [SerializeField]
    public float moveSpeedRight;
    [SerializeField]
    public float moveSpeedLeft;
    [SerializeField]
    public float jumpHeight;
    [SerializeField]
    public float touchspeed;


    MotherCollider colliders;
    Vector3D StartVector;
    Vector3D UpdatePosition;
    Vector3D MovementVector;

    void Start()
    {
        StartVector = new Vector3D(0, 2, 0);
        gameObject.transform.position = StartVector;
        moveSpeedLeft = 0.15f;
        moveSpeedRight = 0.15f;
        touchspeed = 7f;
    }

#if UNITY_STANDALONE
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.D))
        {
            UpdatePosition = Vector3D.Position(this.gameObject);
            this.gameObject.transform.position = StartVector.Translate(new Vector3D(this.gameObject.transform.position.x + moveSpeedRight, UpdatePosition.y, UpdatePosition.z));
        }
        else if (Input.GetKey(KeyCode.A))
        {
            UpdatePosition = Vector3D.Position(this.gameObject);
            this.gameObject.transform.position = StartVector.Translate(new Vector3D(this.gameObject.transform.position.x - moveSpeedLeft, UpdatePosition.y, UpdatePosition.z));
        }

    }
#endif
#if UNITY_ANDROID
    void Update()
    {
        if (StarCountDown.play)
        {
            MovementVector = new Vector3D(0, 0, 0);
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                MovementVector.x = Input.GetTouch(0).deltaPosition.x;
                this.gameObject.GetComponent<Transform>().transform.Translate(MovementVector.x * touchspeed * Time.deltaTime, MovementVector.y, MovementVector.z);
            }
        }
    }

#endif
}
