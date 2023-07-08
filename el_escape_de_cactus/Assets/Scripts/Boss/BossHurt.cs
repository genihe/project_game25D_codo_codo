using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHurt : MonoBehaviour
{
    [SerializeField] private BossHealth bossHealth;
    [SerializeField] private PlayerController playerControl;
    //[SerializeField] private PlayerJump playerJump;
    //[SerializeField] private int playerPower;

    [SerializeField] private float springForce=0.4f;
    // Start is called before the first frame update
    void Start() {}

    // Update is called once per frame
    void Update() {}

    private void OnTriggerEnter(Collider other){
        if (other.tag=="PlayerAttack")
        {
            playerControl.Bounce(springForce);
            DoDamage();            
        }
    }    
    public void DoDamage(){
        bossHealth.GetComponent<IDamageable>().TakeDamage(playerControl.playerPower);
    }
}
