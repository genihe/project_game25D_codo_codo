using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerController playerControl;

    [SerializeField]
    int enemyPower = 1;

    private SoundManager soundManager;

    void Awake(){
        soundManager = FindObjectOfType<SoundManager>();
    }
    void Start() { }

    // Update is called once per frame
    void Update() { }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("tag01: " + other.tag);
        Debug.Log("tag02: " + gameObject.tag);
        if (gameObject.tag == "BubbleGum")
        {
            soundManager.PlayByIndex(6, 0.5f);
        }
        if (other.tag == "PlayerHurt")
        {
            //playerControl.Bounce(enemyPower/8);
            DoDamage();
            //Debug.Log("TOMA ESA CACTUS");
        }
    }

    //Causo Daño a Player
    public void DoDamage()
    {
        playerControl.GetComponent<IDamageable>().TakeDamage(enemyPower);
    }
}
