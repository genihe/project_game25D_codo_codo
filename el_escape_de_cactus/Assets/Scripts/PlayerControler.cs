using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed;
    public float jumpForce;
    public Rigidbody rb;
    void Start()
    {
        rb=GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity=new Vector3(Input.GetAxis("Horizontal") * moveSpeed, rb.velocity.y, Input.GetAxis("Vertical") * moveSpeed);
        if (Input.GetButtonDown("Jump")){
            rb.velocity=new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        }
        //CheckKeys();
    

    }

    /*private void CheckKeys(){
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                Debug.Log("Tecla Izquierda presionada.");
            }

            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                Debug.Log("Tecla izquierda liberada");
            }
        }

    }*/
    
}
