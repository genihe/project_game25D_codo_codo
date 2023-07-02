using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTear : MonoBehaviour
{
    //public PlayerController playerControl;
    [SerializeField] private float healthToGive;

    /*private void Awake()
    {
        instance = this;
    }*/
    
    // Start is called before the first frame update
    void Start(){}

    // Update is called once per frame
    void Update(){}


    private void OnTriggerEnter(Collider other){
        if (other.tag=="Player")
        {
            //playerControl.HurtBounce(hurtForce);
            //DoDamage();

            //Debug.Log("RECARGO VIDA");
            PlayerHealth.instance.Heal(healthToGive);
            Destroy(gameObject);
        }
    }

    /*public void AddLife(){
        PlayerHealth.instance.Heal(healthToGive);
    }*/
}
