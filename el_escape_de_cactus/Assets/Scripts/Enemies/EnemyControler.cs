using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControler : MonoBehaviour
{
    public PlayerController playerControl;
    //[SerializeField] int enemyPower=1;
    //public int enemy_hp = 3;
    Rigidbody rbEnemy;
    //[SerializeField] private float springForce;
    public float moveVelocity=1.5f;
    public int direction_motion=0;

    // Start is called before the first frame update


    void Start() {
        rbEnemy=GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
        Enemy_AI();
    }

    void Enemy_AI(){
        if (direction_motion==0){
            rbEnemy.velocity=new Vector3(moveVelocity, rbEnemy.velocity.y, 0);
        }else{
            rbEnemy.velocity=new Vector3(-moveVelocity, rbEnemy.velocity.y, 0);
        }
        
        
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
