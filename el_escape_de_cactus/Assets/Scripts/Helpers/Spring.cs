using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    public PlayerController playerControl;
    [SerializeField] private float springForce;
    // Start is called before the first frame update
    void Start(){}

    // Update is called once per frame
    void Update(){}

    private void OnTriggerEnter(Collider other){
        if (other.tag=="PlayerAttack"){
            //Debug.Log("RESORTE: Salta Player");
            playerControl.Bounce(springForce);
        }
    }
}
