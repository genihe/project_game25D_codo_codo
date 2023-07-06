using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerController playerControl;
    [SerializeField] int enemyPower=1;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other){
        if (other.tag=="PlayerHurt")
        {
            //playerControl.Bounce(enemyPower/8);
            DoDamage();
            //Debug.Log("TOMA ESA CACTUS");
        }
    }
    //Causo Daño a Player
    public void DoDamage(){
        playerControl.GetComponent<IDamageable>().TakeDamage(enemyPower);
    }


}
