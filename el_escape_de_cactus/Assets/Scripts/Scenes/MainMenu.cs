using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    //public int sceneToLoad; 
    /*void Start()
    {
        
    }/*

    // Update is called once per frame
    /*void Update()
    {
        
    }*/

    public void StartGame(){
        SceneManager.LoadScene("HowToPlay");
    }

    public void Credits(){
        SceneManager.LoadScene("Credits");
    }

    public void QuitGame(){
        Application.Quit();
    }
}
