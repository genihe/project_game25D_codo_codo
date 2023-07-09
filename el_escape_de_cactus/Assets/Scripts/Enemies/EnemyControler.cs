using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControler : MonoBehaviour
{
    public PlayerController playerControl;

    //[SerializeField] int enemyPower=1;
    //public int enemy_hp = 3;
    Rigidbody rbEnemy;
    public AudioSource audioSource;

    //[SerializeField] private float springForce;
    public LayerMask groundLayerMask;
    public float moveVelocity = 1.5f;
    public int direction_motion = 0;

    [SerializeField]
    float height; //Distancia al suelo

    [SerializeField]
    float distance_to_turn; //Distancia al suelo

    // Start is called before the first frame update

    private void Awake() { }

    void Start()
    {
        rbEnemy = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Enemy_AI();
        MotionEnemy();
    }

    void MotionEnemy()
    {
        if (direction_motion == 1)
        {
            rbEnemy.velocity = new Vector3(moveVelocity, rbEnemy.velocity.y, 0);
        }
        else if (direction_motion == -1)
        {
            rbEnemy.velocity = new Vector3(-moveVelocity, rbEnemy.velocity.y, 0);
        }
        else
        {
            rbEnemy.velocity = new Vector3(0, rbEnemy.velocity.y, 0);
        }
        CheckOnPlatForm();
    }

    //Cambio la direccion del movimiento al salirse de la plataforma para que no caiga de la escena
    void CheckOnPlatForm()
    {
        if (!CheckFloor())
        {
            direction_motion *= -1;
            DirectionMotion();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Mamushka (" + gameObject.name + ") collision");
        direction_motion *= -1;
        DirectionMotion();
        //Debug.Log("EnemyController - Collider: " + collision.collider.name);
    }

    void DirectionMotion()
    {
        if (direction_motion == 1)
        { //Right
            transform.rotation = Quaternion.Euler(-90, 0, 0);
        }
        else
        { //Left
            transform.rotation = Quaternion.Euler(-90, 180, 0);
        }
    }

    bool CheckFloor()
    {
        //maxYVel=0.0f;
        //Debug.Log("Estoy en: "+transform.position);
        //RaycastHit hit;
        //Ray ray = new Ray(transform.position, Vector3.down);
        Ray ray = new Ray(
            transform.position + (transform.right * distance_to_turn) + (Vector3.up * 0.01f),
            Vector3.down
        );
        Debug.DrawRay(
            transform.position + (transform.right * distance_to_turn) + (Vector3.up * 0.01f),
            Vector3.down * height,
            Color.blue
        );
        if (Physics.Raycast(ray, height, groundLayerMask))
        {
            return true;
        }
        return false;
    }

    /*void Enemy_AI(){
        if (direction_motion==1){
            rbEnemy.velocity=new Vector3(moveVelocity, rbEnemy.velocity.y, 0);
        }else if (direction_motion==-1){
            rbEnemy.velocity=new Vector3(-moveVelocity, rbEnemy.velocity.y, 0);
        }else{
            rbEnemy.velocity=new Vector3(0, rbEnemy.velocity.y, 0);
        }
        Debug.Log("Check Floor : "+CheckFloor());
        if (!CheckFloor())
        {
            if (direction_motion==1)
            {
                direction_motion=-1;
                transform.rotation = Quaternion.Euler(-90,180,0);
            }else{
                direction_motion=1;
                transform.rotation = Quaternion.Euler(-90,0,0);
            }
        }
        //CheckDirection();
    }*/

    /*private void OnTriggerEnter(Collider other){
        if (other.tag=="PlayerAttack")
        {
            playerControl.Bounce(springForce);

            enemy_hp -= 1;
            Debug.Log("ENEMIGO VIDA : " + enemy_hp);
            //DoDamage();
            if (enemy_hp <= 0)
            {
                
                Defeat();
                //Debug.Log("ESTOY DERROTADO");
            //}
            
            }
        }
    }

    private void Defeat(){
        Debug.Log("ESTOY DERROTADO");
        //this.SetActive(false);
        Destroy(gameObject);
    }*/

    /*public void DoDamage(){
        PlayerHealth.instance.GetComponent<IDamageable>().TakeDamage(enemyPower);
    }*/
}
