using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    // Start is called before the first frame update
    float changeSceneTime=6.0f;
    bool startTimer=false;
    void Start()
    {
        startTimer=true;
    }

    // Update is called once per frame
    void Update()
    {
        if (startTimer)
        {
            Debug.Log("Tiempo : " + changeSceneTime);
            changeSceneTime-=Time.deltaTime;
            if (changeSceneTime < 0)
            {
                startTimer=false;
                ViewCredits();
            }
        }
    }
    private void ViewCredits(){
        SceneManager.LoadScene(0);
    }
}
