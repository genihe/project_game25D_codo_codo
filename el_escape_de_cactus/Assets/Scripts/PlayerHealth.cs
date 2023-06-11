using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour , IDamageable
{
    // Start is called before the first frame update
    public static PlayerHealth instance;
    //public Image healthBar;
    public Text healthBar;
    public int currentHealth;
    [SerializeField] int maxHealth=3;

    private void Awake(){
        instance=this;
    }

    void Start()
    {
        //Asigno la vida maxima a la vida de inicio
        currentHealth=maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        //healthBar.fillAmount=GetPercentage();

        //Actualizo el Text en pantalla al valor de la vida
        healthBar.text=GetLife().ToString();
    }
    public int GetLife(){
        return currentHealth;
    }


    //Problemas al incorporar el paquete 2D Sprite (postergar desarrollo)
    /*public float GetPercentage(){
        return currentHealth / maxHealth;
    }*/

    /*public void Heal (float amount){
        currentHealth=Mathf.Min(currentHealth + amount, maxHealth);
    }*/

    public void TakeDamage (int amount){
        //currentHealth=Mathf.Max(currentHealth - amount, 0.0f);
        currentHealth-=amount;
        if (currentHealth<=0)
        {
            Defeat();
        }
    }

    public void Defeat(){
        //currentHealth=maxHealth;
        Debug.Log("Estoy derrotado  :'-(");
        //reload the SCENE
    }
}

public interface IDamageable{
    void TakeDamage(int amount);
}
