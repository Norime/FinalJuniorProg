using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : CapacityManager
{
    [SerializeField] private float verticalMouseAxe;
    [SerializeField] private float horizontalMouseAxe;
    private Rigidbody playerRb;
    
    private float forwardInput;
    private float horizontalInput;
    public int JumpNumber;
    public float mouseSensibility;
    private GameObject ChildCamera;

    // Start is called before the first frame update
    void Start()
    {
        distToGround = GetComponent<Collider>().bounds.extents.y;
        playerRb = GetComponent<Rigidbody>();
        maxJumpNumber = 3;
        isOnGround = true;
        ChildCamera = transform.GetChild(0).gameObject;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        MovementPlayer();
    }

    private void MovementPlayer()
    {
        //Get Axes input from project property
        forwardInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        horizontalMouseAxe = Input.GetAxis("Mouse X");
        verticalMouseAxe = Input.GetAxis("Mouse Y");
        //Move the player forward ,backward, left and right
        transform.Translate(Vector3.forward * speed * Time.deltaTime * forwardInput);
        transform.Translate(Vector3.right * speed * Time.deltaTime * horizontalInput);
        transform.Rotate(Vector3.up * mouseSensibility * Time.deltaTime * horizontalMouseAxe);
        //vertical axe = camera only
        var cameraRotation = Vector3.left * mouseSensibility * Time.deltaTime * verticalMouseAxe;

        //var cameraRotation = Mathf.Clamp(verticalMouseAxe, -90f, 90f);

        //ChildCamera.transform.rotation = Quaternion.AngleAxis(cameraRotation.x, Vector3.right);
        //ChildCamera.transform.rotation = Quaternion.Euler(0, cameraRotation.x,0);



        ChildCamera.transform.Rotate(cameraRotation, Space.Self);
        cameraRotation.x = Mathf.Clamp(ChildCamera.transform.eulerAngles.y, -90, 90);
        ChildCamera.transform.eulerAngles = cameraRotation;

        //elevation.x = Mathf.Clamp(elevation.x, -90f, 90f);

        //ChildCamera.transform.Rotate(cameraRotation);
        //var rotationTo = ChildCamera.transform.rotation.eulerAngles;
        //rotationTo.x = Mathf.Clamp(rotationTo.x, -90f, 90f);
        //ChildCamera.transform.rotation = Quaternion.Euler(rotationTo);
        //Debug.Log(cameraRotation);
        //Chunk jump possibility
        if (Input.GetKeyDown(KeyCode.Space) && maxJumpNumber > JumpNumber)
        {
            JumpNumber += 1;
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
    }

    /// <summary>
    /// Detect if player as enter in collision with another gameobject
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        if (IsGrounded())
        {
            isOnGround = true;
            JumpNumber = 0;
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            maxJumpNumber -= 1;
            Debug.Log("Max jump -1");
        }

        if (collision.gameObject.CompareTag("PowerUp"))
        {
            maxJumpNumber += 1;
            Destroy(collision.gameObject);
            Debug.Log("Max jump +1");
        }
    }
}
