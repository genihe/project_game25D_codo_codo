using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    // Start is called before the first frame update
    //public Text healthBar;
    public static EnemyHealth instance;
    public int currentHealth;
    
    [SerializeField]
    int maxHealth = 3;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        currentHealth = maxHealth;
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
    }

    public void Defeat()
    {
        Destroy(gameObject);       
    }
}