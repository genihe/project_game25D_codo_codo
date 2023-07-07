using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Candle : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerController playerControl;
    //[SerializeField] int escene=0;

    void Start(){}

    // Update is called once per frame
    void Update() {
        
    }

    private void OnTriggerEnter(Collider other){
        if (other.tag=="Player")
        {
            LevelChange();
            //Debug.Log("Cambio de Nivel");
        }
    }

    public void LevelChange(){
        SceneManager.LoadScene("Level2");
    }
}
