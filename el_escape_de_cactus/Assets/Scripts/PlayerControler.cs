using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float moveSpeed;
    [SerializeField] float walkSpeed;
    [SerializeField] float runSpeed;            //Podria implementarse que mientras se presiona SHIFT, el estado es correr
    [SerializeField] float jumpForce;
    [SerializeField] float height;
    private bool flipPlayer;
    //RaycastHit hit;
    public bool isGrounded;
    public LayerMask groundLayerMask;

    Rigidbody rb;
    void Start()
    {
        rb=GetComponent<Rigidbody>();
        flipPlayer=true;
    }

    // Update is called once per frame
    void Update()
    {
        CheckGround();
        //El player solo posee desplazamiento lateral, IZQ o DER
        Move();
        Jump();
    }

    void Move(){
        float moveValue = Input.GetAxis("Horizontal");
        //Debug.Log(moveValue);
        rb.velocity=new Vector3(moveValue * moveSpeed, rb.velocity.y, 0);
        if (moveValue>0 && !flipPlayer)
            Turn();
        else if (moveValue<0 && flipPlayer)
            Turn();
    }   // Al cambiar de direccion en X el player se debe rotar en la otra direccion*/

    void Jump(){
        if (Input.GetButtonDown("Jump") && isGrounded){
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void Bounce(float impulse){
	    rb.AddForce(Vector3.up * impulse, ForceMode.Impulse);
    }

    void Turn(){
        flipPlayer=!flipPlayer;
        Vector3 turn = transform.localScale;
        turn.x *= -1;
        transform.localScale=turn;
    }

    private void CheckGround(){
        RaycastHit hit;
        Ray ray = new Ray(transform.position, Vector3.down*height);
        Debug.DrawRay(transform.position, Vector3.down * height, Color.blue);
        if (Physics.Raycast(ray, out hit, height, groundLayerMask)){
            isGrounded = true;
        }else{
            isGrounded =false;
        }        
    }

}

