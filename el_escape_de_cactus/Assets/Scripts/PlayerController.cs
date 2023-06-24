using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
//    [SerializeField] int playerHP=3;
    [SerializeField] float moveSpeed;
    [SerializeField] public int playerPower=1;
    [SerializeField] float walkSpeed;
    [SerializeField] float runSpeed;            //Podria implementarse que mientras se presiona SHIFT, el estado es correr
    [SerializeField] float jumpForce=0.5f;    //usado en salto 1

    public float distanceToCheck = 0.2f;
    public bool isGrounded;
    public RaycastHit hit;


    //Sin uso de gravedad
    //[SerializeField] float globalGravity=-2;  //usado en salto 1
    //[SerializeField] float gravityScale=1f;   //usado en salto 1
    //[SerializeField] float freeFallDead=1f;   //usado en salto 1

    //public float jumpTime=1f;
    //Rebote al pisar
    [SerializeField] float height;
    private bool flipPlayer;
    //RaycastHit hit;
    //public bool isGrounded;
    public LayerMask groundLayerMask;
    //Vector3 gravity;                          //usado el salto 1
    Rigidbody rb;
    //float velocity;

    void Start()
    {
        //Requerido para salto sin fisicas
        //gravity = globalGravity * gravityScale * Vector3.up;
        rb=GetComponent<Rigidbody>();
        flipPlayer=false;
        //transform.rotation = Quaternion.Euler(0,120,0);
        
    }

    // Update is called once per frame
    void Update ()
    {    
        //IsGrounded();
        //rb.AddForce(gravity * jumpForce, ForceMode.Acceleration);
        Move(); //El player solo posee desplazamiento lateral, IZQ o DER
        Jump();        
    }

    //---------FUNCTIONS---------
    //Movimiento
    void Move(){
        float moveValue = Input.GetAxis("Horizontal");
        //Debug.Log("Movimiento horizontal : "+moveValue);
        //transform.Translate(Vector3.right * moveValue * moveSpeed * Time.deltaTime, Space.World);
        rb.velocity=new Vector3(moveValue * moveSpeed, rb.velocity.y, 0);

        /*if (moveValue>=0 && !flipPlayer)
            Turn(1);
        else if (moveValue<0 && flipPlayer)
            Turn(0);
        */
    }


    //Salto
    void Jump(){
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity=new Vector3(rb.velocity.x, jumpForce, 0);
        }
    }

    /*void Jump(){
        //Vector3 gravity = globalGravity * gravityScale * Vector3.up;
        if (Input.GetButtonDown("Jump"))
        {
            if(IsGrounded()){
                //rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                rb.velocity=new Vector3(rb.velocity.x, jumpForce, 0);
            }
        }
    }*/

    // --------- REBOTE --------- 
    public void Bounce(float impulse){
        //transform.Translate(new Vector3(0, impulse, 0) * Time.deltaTime);
        //rb.AddForce(Vector3.up * impulse, ForceMode.Impulse);
        
        rb.velocity = new Vector3(rb.velocity.x, impulse, 0);

    }

    void Turn(int dir){
        if(flipPlayer){
            transform.rotation = Quaternion.Euler(0,-120,0);
        }else{
            transform.rotation = Quaternion.Euler(0,120,0);
        }
        flipPlayer=!flipPlayer;
    }




    bool IsGrounded(){
        //Debug.Log("Estoy en: "+transform.position);
        //RaycastHit hit;
        Ray ray = new Ray(transform.position, Vector3.down);
        Debug.DrawRay(transform.position, Vector3.down * height*2, Color.blue);
        if (Physics.Raycast(ray, height, groundLayerMask)){
            return true;
        }
        return false;
    }

    /*void IsGrounded(){
        Ray ray = new Ray(transform.position, Vector3.down);
        isGrounded = Physics.Raycast(ray, out hit, distanceToCheck);
    }*/

/*
    private void CheckGround(){
        //Debug.Log("Estoy en: "+transform.position);
        //RaycastHit hit;
        Ray ray = new Ray(transform.position, Vector3.down);
        Debug.DrawRay(transform.position, Vector3.down * height*2, Color.blue);
        if (Physics.Raycast(ray, out hit, height, groundLayerMask)){
            isGrounded = true;
        }else{
            isGrounded =false;
        }        
    }*/
}

