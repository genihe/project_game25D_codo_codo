using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float moveSpeed;
    [SerializeField] float walkSpeed;
    [SerializeField] float runSpeed;            //Podria implementarse que mientras se presiona SHIFT, el estado es correr
    [SerializeField] float jumpForce=5f;
    //public float jumpTime=1f;
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
        Debug.Log("Movimiento horizontal : "+moveValue);

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

    private void OnCollisionEnter(Collision collision){
        if (collision.gameObject.CompareTag("Hurt"))
        {
            Bounce(jumpForce/3);
        }
    }

    void Bounce(float impulse){
	    rb.AddForce(Vector3.up * impulse, ForceMode.Impulse);
    }

    void Turn(){
        flipPlayer=!flipPlayer;
        transform.Rotate(new Vector3(0f, 180, 0f));
        //Debug.Log("Turn");
    }

    private void CheckGround(){
        Debug.Log("Estoy en: "+transform.position);
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

