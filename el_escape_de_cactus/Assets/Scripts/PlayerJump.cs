using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
/*{
    [SerializeField] float jumpHeight = 5;
    [SerializeField] float gravityScale= 5;
    
    float velocity;
    
    void Update()
    {
        velocity += Physics2D.gravity.y * gravityScale * Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            velocity = Mathf.Sqrt(jumpHeight * -2 *(Physics2D.gravity.y * gravityScale));
        }
        transform.Translate(new Vector3(0, velocity, 0) * Time.deltaTime);
    }
}*/
{
    public GroundCheck3D groundCheck;
    public float jumpForce=2f;
    public float gravity = -1f;
    public float gravityScale = 0.001f;
    float velocity;

    void Update()
    {
        velocity += gravity * gravityScale * Time.deltaTime;
        if (groundCheck.isGrounded && velocity < 0)
        {
            velocity = 0;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            velocity = jumpForce;
        }
        transform.Translate(new Vector3(0, velocity, 0) * Time.deltaTime);
    }
}