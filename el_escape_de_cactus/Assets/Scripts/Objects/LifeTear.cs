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
    private SoundManager soundManager;
    
    // Start is called before the first frame update
    void Start(){}

    private void Awake()
    {
        soundManager = FindObjectOfType<SoundManager>();
    }
    // Update is called once per frame
    void Update(){}


    private void OnTriggerEnter(Collider other){
        if (other.tag=="Player")
        {
            //playerControl.HurtBounce(hurtForce);
            //DoDamage();

            //Debug.Log("RECARGO VIDA");
            PlayerHealth.instance.Heal(healthToGive);
            soundManager.PlayByIndex(3, 0.5f);//Reproduce el sonido [0] de la lista de sonidos del SoundManager
            Destroy(gameObject);
        }
    }

    /*public void AddLife(){
        PlayerHealth.instance.Heal(healthToGive);
    }*/
}
