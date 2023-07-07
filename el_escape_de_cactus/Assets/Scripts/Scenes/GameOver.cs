using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public float timeRemaining = 10;
    
    private SoundManager soundManager;

    private void Awake()
    {
        soundManager = FindObjectOfType<SoundManager>();
    }
    // Start is called before the first frame update
    void Start(){
        soundManager.PlayByIndex(0, 1f); //Reproduce el sonido [0] de la lista de sonidos del SoundManager de Game Over
    }

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
