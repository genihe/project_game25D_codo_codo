using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public PlayerController playerControl;
    [SerializeField] int enemyPower=1;

    // Start is called before the first frame update
    void Start() {}

    // Update is called once per frame
    void Update() {}

    private void OnTriggerEnter(Collider other){
        if (other.tag=="PlayerHurt")
        {
            //playerControl.IsHurt();
            DoDamage();
            Debug.Log("TOMA ESA CACTUS");
            //other.transform.parent.gameObject.SetActive(false);
        }
    }

    //Causo Daño a Player
    public void DoDamage(){
        playerControl.GetComponent<IDamageable>().TakeDamage(enemyPower);
    }

}
