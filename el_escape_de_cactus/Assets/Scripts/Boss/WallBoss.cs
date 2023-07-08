using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBoss : MonoBehaviour
{
    public GameObject main_camera;
    public bool bossArea=false;
    //private Collider wallBoss;
    // Start is called before the first frame update
    void Start()
    {
        //wallBoss=GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other){
        if (other.tag=="Player" && bossArea==false)
        {
            Debug.Log("Entre a la zona jefe");
            GetComponent<BoxCollider>().enabled=false;
            
        }
    }
}
