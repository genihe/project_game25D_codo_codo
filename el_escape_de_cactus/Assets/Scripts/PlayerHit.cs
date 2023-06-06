using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision){
        if (collision.gameObject.CompareTag("Hit"))
        {
           //Defeat();
           print("Estoy lastimado  !!!!!!!!");
        }
    }

    /*void Defeat(){
         Debug.Log("Enemy is HURT");
    }*/
}
