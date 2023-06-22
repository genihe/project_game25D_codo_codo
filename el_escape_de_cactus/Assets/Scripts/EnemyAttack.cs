using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public PlayerController playerControl;
    [SerializeField] int enemyPower=1;
    //public int enemy_hp = 3;

    //[SerializeField] float springForce=0.5f;
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {}

    private void OnTriggerEnter(Collider other){
        if (other.tag=="PlayerHurt")
        {
            //playerControl.HurtBounce(hurtForce);
            DoDamage();
            Debug.Log("TOMA ESA CACTUS");
            //other.transform.parent.gameObject.SetActive(false);
        }
    }

    /*private void Defeat(){
        Debug.Log("ESTOY DERROTADO");
    }*/

    //Causo Daño a Player
    public void DoDamage(){
        playerControl.GetComponent<IDamageable>().TakeDamage(enemyPower);
    }

}
