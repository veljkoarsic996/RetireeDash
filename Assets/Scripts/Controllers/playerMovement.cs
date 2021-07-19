using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerMovement : MonoBehaviour
{
    public GameObject pause;
    public CharacterController controller;
    public Transform cam;
    public Transform groundCheck;
    public GameObject playerObject;
    public float groundDistance = 0f;
    public LayerMask groundMask;
    bool isGrounded;
    bool moving;
    bool falling;
    public float jumpHeight = 3f;
    float deltaT = 0.0f;
    public int jumpLimit = 2;
    int jumpCount;

     float speed = 4f;
    public float turnSmoothTime = 0.1f;

    float targetAngle;
    float angle;


    float turnSmoothVelocity;
    Vector3 velocity;
    public float gravity = -9.81f;
    public Animator anim;
    EnemyController radius;
    public Text state;
    public GameObject Pauza;

    private void Start()
    {   
        
        anim = GetComponent<Animator>();

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }
    private void Awake()
    {

        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 300;
    }
    void Update()
    {
        moving = isMoving();
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        //  Debug.LogError(health);
        Debug.Log(isGrounded);

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3(horizontal, 0, vertical).normalized;

        if (Input.GetKey(KeyCode.P)) {
            Time.timeScale = 0;
            pause.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        

        if (moving == true)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                anim.SetBool("running", true);
                speed = 8f;
            }
            else if (Input.GetKeyUp(KeyCode.LeftShift))
            {

                anim.SetBool("running", false);
                anim.SetInteger("condition", 1);
                speed = 4f;
            }

            anim.SetInteger("condition", 1);
            Debug.Log("MOVING");
        }
        else if (moving == false)
        {

            anim.SetInteger("condition", 0);
            dir = Vector3.zero;
            Debug.Log("NOT-MOVING");
        }

        if (!isGrounded)
        {
            anim.SetBool("falling", true);
            moving = false;
        }

        if (isGrounded && velocity.y < 0)
        {
            anim.SetBool("falling", false);
            velocity.y = -2f;
        }
        if (dir.magnitude >= 0.1f)
        {
            targetAngle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            playerObject.transform.rotation = Quaternion.Euler(0f, angle, 0f);

            anim.SetInteger("condition", 1);
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

           

            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            anim.SetInteger("condition", 2);
            moving = false;
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

        }

       
       

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }


    

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, 10);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 2);
    }


    bool isMoving()
    {
        bool charIsMoving = false;

        if (Input.GetKey(KeyCode.W))
        {
            charIsMoving = true;
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            charIsMoving = false;
        }
        if (Input.GetKey(KeyCode.S))
        {
            charIsMoving = true;
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            charIsMoving = false;
        }
        if (Input.GetKey(KeyCode.A))
        {
            charIsMoving = true;
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            charIsMoving = false;
        }
        if (Input.GetKey(KeyCode.D))
        {
            charIsMoving = true;
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            charIsMoving = false;
        }



        return charIsMoving;
    }


}

