using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
//Salto usando RigidBody
{
    public GroundCheck3D groundCheck;
    public float jumpForce=2f;
    public float gravity = -1f;
    public float gravityScale = 0.001f;
    Rigidbody rb;
    float velocity;

    void Start(){
         rb= GetComponent<Rigidbody>();
    }

    void Update()
    {
        velocity += gravity * gravityScale * Time.deltaTime;
        Jump();
    }

    void Jump(){
        
        if (groundCheck.isGrounded && velocity < 0)
        {
            velocity = 0;
        }
        if (Input.GetKeyDown(KeyCode.Space) && groundCheck.isGrounded)
        {
            velocity = jumpForce;
        }
        rb.velocity=new Vector3(rb.velocity.x, velocity, 0);
        //Debug.Log("Velocidad : "+velocity);
        //transform.Translate(new Vector3(0, velocity, 0) * Time.deltaTime);
    }


}


//SALTO usando Transform
/*{
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
}*/