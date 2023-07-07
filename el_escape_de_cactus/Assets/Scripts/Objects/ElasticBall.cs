using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElasticBall : MonoBehaviour
{
    public PlayerController playerControl;
    [SerializeField] float powerUp=0.1f;
    private SoundManager soundManager;
    void Awake(){
        soundManager = FindObjectOfType<SoundManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other){
        if (other.tag=="Player")
        {
            soundManager.PlayByIndex(4, 0.5f);//Reproduce el sonido [0] de la lista de sonidos del SoundManager
            playerControl.SetPowerUp(powerUp);
            Destroy(gameObject);
        }
    }

}
