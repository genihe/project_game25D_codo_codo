using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody rb;
    [SerializeField] float movementSpeed=0.6f;
    [SerializeField]float jumpForce=0.5f;

    public GroundCheck3D groundCheck;

    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody>();   
    }

    // Update is called once per frame
    void Update()
    {
        float horizantalInput=Input.GetAxis("Horizontal");
        float verticalInput=Input.GetAxis("Vertical");

        rb.velocity=new Vector3(horizantalInput * movementSpeed, rb.velocity.y, verticalInput*movementSpeed);

        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity=new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        }
    }
}
