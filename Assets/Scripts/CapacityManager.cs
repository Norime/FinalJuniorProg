using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapacityManager : MonoBehaviour
{
    public float healPoint;
    public int maxJumpNumber;
    public float speed;
    public float jumpForce;
    public float distToGround;
    public bool isOnGround;
    // Start is called before the first frame update
    public void Jump()
    {

    }

    /// <summary>
    /// Check if player as on the ground
    /// </summary>
    /// <returns></returns>
    public bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
    }
}
