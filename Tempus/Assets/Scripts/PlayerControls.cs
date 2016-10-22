using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour
{
    public float horizontalMouseSensitivity = 10.0f;

    private float rotY = 0.0f; // rotation around the up/y axis
    private float rotX = 0.0f; // rotation around the right/x axis    

    public GameObject[] muzzles;
    int currentMuzzleIndex = 0;
    
    GameManager gameManager;
    private Transform myTransform;
    private Vector3 playerPosition;
    public float walkSpeed = 3.0f;
    public float originalWalkSpeed = 3.0f;
    public float runSpeed = 5.0f;

    public float distanceToGround;
    public float jumpForce = 200.0f;
    
    public float liftTime = 2.0f;
    public bool hasJumped = false;    
    
    bool paused = false;
    
    CameraRotate camRot;

    int xpos = (Screen.width) / 2;
    int ypos = (Screen.height) / 2;

    // Use this for initialization
    void Start()
    {
        Cursor.visible = false;

        camRot = GetComponentInChildren<CameraRotate>();

        myTransform = this.transform;

        Vector3 rot = transform.localRotation.eulerAngles;
        rotY = rot.y;
        rotX = rot.x;
    }

    bool invertMouse = false;

    // Update is called once per frame
    void Update()
    {
        Movement();

        CameraRotation();      

        pausing();
                
        Object.DontDestroyOnLoad(transform.gameObject);
    }

    void CameraRotation()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = -Input.GetAxis("Mouse Y");

        rotY += mouseX * horizontalMouseSensitivity;

        Quaternion localRotation = Quaternion.Euler(0.0f, rotY, 0.0f);
        transform.rotation = localRotation;        
    }

    void Movement()
    {
        //Movement: Left and Right
        if (Input.GetKey("a"))
        {
            if (CheckGrounded())
            {
                transform.position -= transform.right * walkSpeed * Time.deltaTime;
            }

            else transform.position -= transform.right * walkSpeed * Time.deltaTime;            
        }

        if (Input.GetKey("d"))
        {
            if (CheckGrounded())
            {
               transform.position += transform.right * walkSpeed * Time.deltaTime;
            }

            else transform.position += transform.right * walkSpeed * Time.deltaTime;            
        }

        if (Input.GetKey("s"))
        {
            if (CheckGrounded())
            {
                transform.position -= transform.forward * walkSpeed * Time.deltaTime;
            }

            else transform.position -= transform.forward * walkSpeed * Time.deltaTime;
        }

        if (Input.GetKey("w"))
        {
            if (CheckGrounded())
            {
                transform.position += transform.forward * walkSpeed * Time.deltaTime;
            }
            
            else transform.position += transform.forward * walkSpeed * Time.deltaTime;
        }

        if (Input.GetKeyDown("space") && CheckGrounded())
        {
            Debug.Log("jumping");
            myTransform.GetComponent<Rigidbody>().AddForce((myTransform.up * jumpForce));            
            hasJumped = true;
        }        

        if (Input.GetKey("left shift") && CheckGrounded())
        {
            walkSpeed = runSpeed;
        }

        if (Input.GetKeyUp("left shift") && CheckGrounded())
        {
            walkSpeed = originalWalkSpeed;
        }
    }
     
    public bool CheckGrounded()
    {
        if(Physics.Raycast(myTransform.position, -Vector3.up, 2f))
        {
            hasJumped = false;
            return true;
        }
        else return false;
    }    
           
    public void pausing()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Cursor.visible = false;
            paused = togglePause();
        }
            
    }

    void OnGUI()
    {
        if (paused)
        {
            camRot.verticalMouseSensitivity = 0;
            Cursor.visible = true;
            if (GUI.Button(new Rect(xpos - 50, ypos- 150, 100, 30), "Resume"))
            {                
                paused = togglePause();
                Cursor.visible = false;
            }

            if (GUI.Button(new Rect(xpos - 50, ypos - 100, 100, 30), "Main Menu"))
            {
                paused = togglePause();                
                Application.LoadLevel("Main Menu");
                Destroy(this.gameObject, 0.1f);
            }

            if (GUI.Button(new Rect(xpos - 50, ypos - 50, 100, 30), "Invert Look"))
            {
                invertMouse = invertingMouse();
            }
        }
    }

    bool togglePause()
    {
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
            return (false);
        }
        else
        {
            Time.timeScale = 0f;
            return (true);
        }
    }

    bool invertingMouse()
    {
        if(camRot.verticalMouseSensitivity > 0)
        {
            camRot.verticalMouseSensitivity -= camRot.verticalMouseSensitivity - camRot.verticalMouseSensitivity;
            return (false);
        }

        else
        {
            camRot.verticalMouseSensitivity += camRot.verticalMouseSensitivity + camRot.verticalMouseSensitivity;
            return (true);
        }
    }
    
}


    

