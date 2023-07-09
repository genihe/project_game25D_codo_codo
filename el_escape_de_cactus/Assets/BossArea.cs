using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossArea : MonoBehaviour
{
    public GameObject boss;
    public PlayerController hero;

    private void Awake()
    {
    }
    // Start is called before the first frame update
    void Start() {
            }

    // Update is called once per frame
    void Update()
    {
        if (boss == null)
        {
            hero.SetTimeSpeed(0.4f);
            Invoke("LoadCreditScene",1f);
        }
    }

   private void LoadCreditScene()
    {
        SceneManager.LoadScene("Credits");
    }
}
