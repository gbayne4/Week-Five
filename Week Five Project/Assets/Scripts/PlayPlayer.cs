using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Thank you Professor Wengu for  the rotation code, it made a lot more sense than what I usually do / try to do


//I attempted adding in a struct, I hope I did it correctly.
public struct PlayerInfo //stored my players info in a struct
{
    public float speed;
    public float drag;
    public float jump;

    public PlayerInfo(float s, float d, float j)
    {
        speed = s;
        drag = d;
        jump = j;
    }
}



public class PlayPlayer : MonoBehaviour
{
    Rigidbody rb;
    // Start is called before the first frame update
    private CharacterController playerController;


    [SerializeField]
    private float currentYVelocity;
    [SerializeField]
    private float mouseSensitivity;

    public static int fish = 18;
    PlayerInfo thisplayer;

    Transform cameraTrans;
    float cameraPitch = 0;
    float gravityValue = Physics.gravity.x;

    void Start()
    {
         thisplayer = new PlayerInfo(5, 2, 1000);

        rb = gameObject.GetComponent<Rigidbody>();
        rb.drag = thisplayer.drag;

        playerController = GetComponent<CharacterController>();
        cameraTrans = Camera.main.transform;

        //locking in the center + hiding
        Cursor.lockState = CursorLockMode.Locked; //not sure what we are using this for just yet
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {


        if(!GameManager.instance.isGameOver)
        {
            Vector2 mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

     //Code for looking around



            //beautiful, I struggled trying to make something like this in my previous games
            transform.Rotate(Vector3.up * mouseDelta.x * mouseSensitivity);

            cameraPitch -= mouseDelta.y * mouseSensitivity;
            //prevents a full rotation
            cameraPitch = Mathf.Clamp(cameraPitch, -98, 90);
            cameraTrans.localEulerAngles = Vector3.right * cameraPitch;

            /* decided not to use this form of movement for my game
            Vector3 move = transform.rotation * new Vector3(
                Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical")
                );

            // playerController.Move(move * Time.deltaTime * speed);

            */



    //Code for moving character 

            if (Input.GetKey(KeyCode.W))//going forward
            {
                rb.AddForce(transform.forward * thisplayer.speed);
            }
            if (Input.GetKey(KeyCode.S)) //going backwards
            {
                rb.AddForce(-transform.forward * thisplayer.speed);
            }

            if (Input.GetKey(KeyCode.A))
            {

                rb.AddForce(-transform.right * thisplayer.speed);
            }


            if (Input.GetKey(KeyCode.D)) //going right
            {
                rb.AddForce(transform.right * thisplayer.speed);
            }

            //Code for jumping
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(transform.up * thisplayer.jump);
            }


            }
        
    }
    private void OnCollisionEnter(Collision collision) //when it collides with fish, it detroys them
    {
        if ((collision.gameObject.tag == "Fish") && (Input.GetKey(KeyCode.E)))
        {
            Destroy(collision.gameObject);
            fish -= 1;
        }
    }
}
