using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    private Rigidbody cactusRB;
    
    private void OnTriggerEnter(Collider other){
        if (other.tag=="EnemyHurt")
        {
            //cactusRB.velocity=new Vector3(cactusRB.velocity.x, 0f ,0f);
            //cactusRB.AddForce(Vector3.up * 50f);
        }
    }
}
