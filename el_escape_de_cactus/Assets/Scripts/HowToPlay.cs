using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HowToPlay : MonoBehaviour
{
    public float timeRemaining = 10;
    
    // Start is called before the first frame update
    void Start(){}

    // Update is called once per frame
    void Update()
    {
        if (timeRemaining > 0){
            timeRemaining -= Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.Return) || timeRemaining<0){
            SceneManager.LoadScene("Level1");
        }
    }
}
