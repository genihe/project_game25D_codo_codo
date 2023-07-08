using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour, IDamageable
{
    // Start is called before the first frame update
    //public Text healthBar;
    public static BossController bossClock;
    public static BossHealth instance;
    private SoundManager soundManager;
    public int currentHealth;
    public bool isDefeat;

    [SerializeField]
    int maxHealth = 30;

    private void Awake()
    {
        instance = this;
        soundManager = FindObjectOfType<SoundManager>();
    }

    void Start()
    {
        currentHealth = maxHealth;
        bossClock=GetComponent<BossController>();
        //soundManager.PlayInLoopByIndex(2,0.1f); //El sonido de deslizamiento
    }

    // Update is called once per frame
    /*void Update()
    {
        healthBar.text = GetLife().ToString();
    }*/

    public int GetLife()
    {
        return currentHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth = currentHealth - amount >= 0 ? currentHealth - amount : 0;
        if (currentHealth <= 0)
        {
            Defeat();
        }
        bossClock.GroggyTime(1,true);
        soundManager.PlayByIndex(1, 0.5f);
    }

    public void Defeat()
    {
        soundManager.PlayByIndex(5, 0.5f);
        bossClock.isDefeat=true;
        this.enabled=false;
        //Destroy(gameObject,1);
    }
}