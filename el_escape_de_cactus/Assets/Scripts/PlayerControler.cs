using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float moveSpeed;
    [SerializeField] float jumpForce;
    bool isGrounded;

    Rigidbody rb;
    void Start()
    {
        rb=GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    void Move(){
        float moveValue = Input.GetAxis("Horizontal");
        Debug.Log(moveValue);
        rb.velocity=new Vector3(moveValue * moveSpeed, rb.velocity.y, 0);
    }   // Al cambiar de direccion en X el player se debe rotar en la otra direccion

    void Jump(){
        if (Input.GetButtonDown("Jump")){
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }   // El salto debe corregirse ya que se puede realizar en el aire indefinidamente. Solo realizar si esta en el SUELO
}
