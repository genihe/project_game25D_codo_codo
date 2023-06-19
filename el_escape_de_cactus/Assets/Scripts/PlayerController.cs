using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int playerHP=3;
    [SerializeField] float moveSpeed;
    [SerializeField] float walkSpeed;
    [SerializeField] float runSpeed;            //Podria implementarse que mientras se presiona SHIFT, el estado es correr
    [SerializeField] float jumpForce=0.5f;

    //Sin uso de gravedad
    [SerializeField] float globalGravity=-2; 
    [SerializeField] float gravityScale=1f;


    //public float jumpTime=1f;
    //Rebote al pisar
    [SerializeField] float height;
    private bool flipPlayer;
    //RaycastHit hit;
    public bool isGrounded;
    public LayerMask groundLayerMask;

    Rigidbody rb;

    void Start()
    {
        rb=GetComponent<Rigidbody>();
        flipPlayer=false;
        transform.rotation = Quaternion.Euler(0,120,0);

    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        //Requerido para salto sin fisicas
        Vector3 gravity = globalGravity * gravityScale * Vector3.up;
        rb.AddForce(gravity * jumpForce, ForceMode.Acceleration);
        //---------

        CheckGround();
        Move(); //El player solo posee desplazamiento lateral, IZQ o DER
        Jump();
        
    }

    void Move(){
        float moveValue = Input.GetAxis("Horizontal");
        //Debug.Log("Movimiento horizontal : "+moveValue);

        rb.velocity=new Vector3(moveValue * moveSpeed, rb.velocity.y, 0);
        if (moveValue>0 && !flipPlayer)
            Turn();
        else if (moveValue<0 && flipPlayer)
            Turn();
    }   // Al cambiar de direccion en X el player se debe rotar en la otra direccion*/

    //Salto con gravedad por fisicas
    /*void Jump(){         
        if (Input.GetButtonDown("Jump") && isGrounded){
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }*/

    //Salto con gravedad calcula
    void Jump(){
        //Vector3 gravity = globalGravity * gravityScale * Vector3.up;
        if (Input.GetButtonDown("Jump") && isGrounded){
            //Debug.Log("SALTO!!");
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    // --------- RECIBO IMPACTO --------- 
    public void Bounce(float impulse){
	    rb.AddForce(Vector3.up * impulse, ForceMode.Impulse);
    }

    void Turn(){
        if(flipPlayer){
            transform.rotation = Quaternion.Euler(0,-120,0);
        }else{
            transform.rotation = Quaternion.Euler(0,120,0);
        }
        flipPlayer=!flipPlayer;
        //transform.Rotate(new Vector3(0f, -120, 0f));
        

        //Debug.Log("Turn");
    }

    private void CheckGround(){
        //Debug.Log("Estoy en: "+transform.position);
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

