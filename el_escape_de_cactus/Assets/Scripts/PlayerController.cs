using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] public int playerPower=1;
    [SerializeField] float walkSpeed;
    [SerializeField] float runSpeed;                                    //Podria implementarse que mientras se presiona SHIFT, el estado es correr
    [SerializeField] float jumpForce=0.5f;                              //usado en salto 1
    [SerializeField] float maxHeightFall=0.7f;                          //usado en salto 1

    public RaycastHit hit;

    [SerializeField] float height;                                      //Distancia al suelo
    //private bool flipPlayer;
    public LayerMask groundLayerMask;
    
    Rigidbody rb;
    Animator anim;

    float auxDir;                               //1:right   /   0:left

    void Start()
    {
        rb=GetComponent<Rigidbody>();
        anim=GetComponent<Animator>();
        transform.rotation = Quaternion.Euler(0,120,0);                 //Rotacion inicial del player
        auxDir=1f;
    }

    // Update is called once per frame
    void Update ()
    {
        //rb.AddForce(gravity * jumpForce, ForceMode.Acceleration);
        Move(); //El player solo posee desplazamiento lateral, IZQ o DER
        Jump();
        anim.SetBool("isGround", IsGrounded());
        //Debug.Log("Velocidad de caida : "+maxYVel);
    }

    //---------FUNCTIONS---------
    //Movimiento
    void Move(){
        float moveValue = Input.GetAxis("Horizontal");
        anim.SetFloat("Speed", Mathf.Abs(moveValue));
        rb.velocity=new Vector3(moveValue * moveSpeed, rb.velocity.y, 0);
        if (moveValue>0){
            Turn(moveValue);
            auxDir=moveValue;
        }else if (moveValue<0){
            Turn(moveValue);
            auxDir=moveValue;
        }else{
            Turn(auxDir);
        }
    }


    //Salto
    void Jump(){
        if (Input.GetButtonDown("Jump") && IsGrounded()){
            rb.velocity=new Vector3(rb.velocity.x, jumpForce, 0);
        }
        if(!IsGrounded()){
            //maxYVel = rb.velocity.y;
            //Debug.Log("Velocidad de caida : " + maxYVel);
            if (rb.velocity.y < -maxHeightFall){
                SceneManager.LoadScene(0);
            }
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
        rb.velocity = new Vector3(rb.velocity.x, impulse, 0);
    }

    void Turn(float dir){
        if(dir<0){
            //Debug.Log("A la Derecha");
            transform.rotation = Quaternion.Euler(0,-120,0);
        }else{
            //Debug.Log("A la Izquierda");
            transform.rotation = Quaternion.Euler(0,120,0);
        }
    }

    bool IsGrounded(){
        //maxYVel=0.0f;
        //Debug.Log("Estoy en: "+transform.position);
        //RaycastHit hit;
        Ray ray = new Ray(transform.position, Vector3.down);
        Debug.DrawRay(transform.position, Vector3.down * height, Color.blue);
        if (Physics.Raycast(ray, height, groundLayerMask)){
            return true;
        }
        return false;
    }

    /*void IsGrounded(){
        Ray ray = new Ray(transform.position, Vector3.down);
        isGrounded = Physics.Raycast(ray, out hit, distanceToCheck);
    }*/
}

