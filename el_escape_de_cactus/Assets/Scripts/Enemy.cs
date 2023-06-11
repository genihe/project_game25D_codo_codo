using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public PlayerController playerControl;
    
    public int enemy_hp = 3;

    //[SerializeField] float springForce=0.5f;
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {}

    private void OnTriggerEnter(Collider other){
        if (other.tag=="PlayerAttack")
        {
            //playerControl.Bounce(springForce);
            enemy_hp -= 1;
            Debug.Log("Mi vida es : "+enemy_hp);
            if (enemy_hp == 0)
            {
                Defeat();
                //Debug.Log("ESTOY DERROTADO");
            }
            //other.transform.parent.gameObject.SetActive(false);
        }
    }

    private void Defeat(){
        Debug.Log("ESTOY DERROTADO");
    }

}
