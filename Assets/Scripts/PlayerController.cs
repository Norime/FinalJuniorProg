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
    private int JumpNumber;
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
        ChildCamera.transform.Rotate(Vector3.left * mouseSensibility * Time.deltaTime * verticalMouseAxe);
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
