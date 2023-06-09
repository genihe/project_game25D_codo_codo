using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private void OnTriggerEnter(Collider other){
        if (other.tag=="Enemy")
        {
           //Defeat();
           print("Pise al enemigo");
           
        }

        if (other.tag=="Enemy")
        {
           //Defeat();
           print("Pise al enemigo");
           
        }

    }

    /*void Defeat(){
         Debug.Log("Enemy is HURT");
    }*/
}
