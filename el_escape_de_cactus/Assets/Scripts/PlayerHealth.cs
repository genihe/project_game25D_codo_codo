using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    // Start is called before the first frame update
    public static PlayerHealth instance;
    //public Image healthBar;
    public float currentHealth;
    public float maxHealth=5;

    private void Awake(){
        instance=this;
    }

    void Start()
    {
        currentHealth=maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        //healthBar.fillAmount=GetPercentage();
    }

    public float GetPercentage(){
        return currentHealth / maxHealth;
    }

    public void Heal (float amount){
        currentHealth=Mathf.Min(currentHealth + amount, maxHealth);
    }

    public void TakeDamage (float amount){
        currentHealth=Mathf.Max(currentHealth - amount, 0.0f);
        if (currentHealth<=0)
        {
            Defeat();
        }
    }

    public void Defeat(){
        currentHealth=maxHealth;
        //reload the SCENE
    }
}

public interface IDamageable{
    void TakeDamage(float amount);
}
