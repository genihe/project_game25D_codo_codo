using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollisions : MonoBehaviour
{
    [SerializeField] GameObject box;
    Rigidbody rb_player;

    private void OnTriggerEnter(Collider other){
        Debug.Log("Entrando en " + other.gameObject.name);
    }

    private void OnTriggerStay(Collider other){
        Debug.Log("Dentro de " + other.gameObject.name);
    }

    private void OnTriggerExit(Collider other){
        Debug.Log("Saliendo de " + other.gameObject.name);
    }
}
