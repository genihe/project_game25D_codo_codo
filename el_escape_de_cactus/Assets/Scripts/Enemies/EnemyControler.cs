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
    public float moveVelocity=1.5f;
    public int direction_motion=0;
    [SerializeField] float height;              //Distancia al suelo
    [SerializeField] float distance_to_turn;              //Distancia al suelo


    // Start is called before the first frame update

    private void Awake()
    {
    }

    void Start() {
        rbEnemy=GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
        Enemy_AI();
    }

    void Enemy_AI(){
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
        
    }

    bool CheckFloor(){

        //maxYVel=0.0f;
        //Debug.Log("Estoy en: "+transform.position);
        //RaycastHit hit;
        //Ray ray = new Ray(transform.position, Vector3.down);
        Ray ray = new Ray(transform.position+(transform.right * distance_to_turn)+(Vector3.up*0.01f), Vector3.down);
        Debug.DrawRay(transform.position+(transform.right * distance_to_turn)+(Vector3.up*0.01f), Vector3.down * height, Color.blue);
        if (Physics.Raycast(ray, height, groundLayerMask)){
            return true;
        }
        return false;
    }
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
