using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public PlayerController playerControl;
    //[SerializeField] int enemyPower=1;
    public int enemy_hp = 3;

    //[SerializeField] float springForce=0.5f;
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {}

    /*private void OnTriggerEnter(Collider other){
        if (other.tag=="PlayerAttack")
        {
            //playerControl.Bounce(springForce);
            //enemy_hp -= 1;
            Debug.Log("ENEMIGO: Fui pisado");
            //if (enemy_hp == 0)
            //{
            //    Defeat();
                //Debug.Log("ESTOY DERROTADO");
            //}
            //other.transform.parent.gameObject.SetActive(false);
        }
    }*/

    private void Defeat(){
        Debug.Log("ESTOY DERROTADO");
    }

    /*public void DoDamage(){
        PlayerHealth.instance.GetComponent<IDamageable>().TakeDamage(enemyPower);
    }*/

}