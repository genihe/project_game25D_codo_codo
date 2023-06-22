using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHurt : MonoBehaviour
{
    [SerializeField] private EnemyHealth enemyHealth;
    [SerializeField] private PlayerController playerControl;
    //[SerializeField] private int playerPower;

    [SerializeField] private float springForce;
    // Start is called before the first frame update
    void Start() {}

    // Update is called once per frame
    void Update() {}

    private void OnTriggerEnter(Collider other){
        if (other.tag=="PlayerAttack")
        {
            playerControl.Bounce(springForce);
            
            Debug.Log("ENEMIGO GOLPEADO : " + enemyHealth.currentHealth);

            DoDamage();            
            /*/if (enemy_hp <= 0)
            {
                Defeat();
            }*/
        }
    }

    private void Defeat(){
        Debug.Log("ESTOY DERROTADO");
        //this.SetActive(false);
        Destroy(gameObject);
    }
    
    public void DoDamage(){
        enemyHealth.GetComponent<IDamageable>().TakeDamage(playerControl.playerPower);
    }
    

}
