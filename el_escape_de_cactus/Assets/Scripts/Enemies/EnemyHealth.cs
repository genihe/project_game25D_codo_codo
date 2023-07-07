using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    // Start is called before the first frame update
    //public Text healthBar;
    public static EnemyHealth instance;
    private SoundManager soundManager;
    public int currentHealth;

    [SerializeField]
    int maxHealth = 3;

    private void Awake()
    {
        instance = this;
        soundManager = FindObjectOfType<SoundManager>();
    }

    void Start()
    {
        currentHealth = maxHealth;
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
        soundManager.PlayByIndex(1, 0.5f);
    }

    public void Defeat()
    {
        soundManager.PlayByIndex(6, 0.5f);
        Destroy(gameObject);
    }
}
