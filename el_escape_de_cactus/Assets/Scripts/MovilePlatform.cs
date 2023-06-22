//using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovilePlatform : MonoBehaviour
{

    [SerializeField] private Transform[] puntosMovimiento;
    [SerializeField] private float velocidadMovimientos;
    private int siguientePlataforma = 1;
    private bool ordenPlataformas=true;

    private void Update(){
        if(ordenPlataformas && siguientePlataforma + 1 >= puntosMovimiento.Length){
            ordenPlataformas=false;
        }
        if(!ordenPlataformas && siguientePlataforma <= 0){
            ordenPlataformas=true;
        }
        if(Vector3.Distance(transform.position, puntosMovimiento[siguientePlataforma].position) < 0.001f){
            if (ordenPlataformas){
                siguientePlataforma+=1;
            } else {
                siguientePlataforma-=1;
            }
        }
        transform.position=Vector3.MoveTowards(transform.position, puntosMovimiento[siguientePlataforma].position, velocidadMovimientos*Time.deltaTime);
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Player")){
            other.transform.SetParent(this.transform);
        }
    }
    private void OnCollisionExit(Collision other) {
        if(other.gameObject.CompareTag("Player")){
            other.transform.SetParent(null);
        }
    }

}
