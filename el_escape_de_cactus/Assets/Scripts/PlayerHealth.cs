using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    // Start is called before the first frame update
    public static PlayerHealth instance;

    public Image healthBar;
    public Text healthText;
    //public int currentHealth;
    public float currentHealth;

    [SerializeField]
    int maxHealth = 3;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        //Asigno la vida maxima a la vida de inicio
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount=GetPercentage();

        //Actualizo el Text en pantalla al valor de la vida
        healthText.text = GetLife().ToString();
    }

    public float GetLife()
    {
        return currentHealth;
    }

    //Problemas al incorporar el paquete 2D Sprite (postergar desarrollo)
    public float GetPercentage(){
        return currentHealth / maxHealth;
    }

    public void Heal (float amount){
        currentHealth=Mathf.Min(currentHealth + amount, maxHealth);
    }

    public void TakeDamage(int amount)
    {
        currentHealth=Mathf.Max(currentHealth - amount, 0.0f);
        //currentHealth = currentHealth - amount >= 0 ? currentHealth - amount : 0;
        if (currentHealth <= 0)
        {
            Defeat();
        }
    }

    public void Defeat()
    {
        currentHealth=maxHealth;
        //Debug.Log("Estoy derrotado  :'-(");


        //Dirigir a escena de derrota
        SceneManager.LoadScene(0);
        //
    }
}

public interface IDamageable
{
    void TakeDamage(int amount);
}
