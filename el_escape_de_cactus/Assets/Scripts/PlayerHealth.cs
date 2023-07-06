using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    // Start is called before the first frame update
    public static PlayerHealth instance;
    public PlayerController playerControl;

    public Image healthBar;
    public Text healthText;
    //public int currentHealth;
    public float currentHealth;

    [SerializeField]
    int maxHealth = 3;
    Animator animator;
    public AudioSource audioSource;
    private SoundManager soundManager;

    private void Awake()
    {
        instance = this;
        soundManager = FindObjectOfType<SoundManager>();
    }

    void Start()
    {
        //Asigno la vida maxima a la vida de inicio
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
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
        playerControl.IsHurt();
        currentHealth=Mathf.Max(currentHealth - amount, 0.0f);
        //currentHealth = currentHealth - amount >= 0 ? currentHealth - amount : 0;
        
        animator.SetBool("isHurt", true);
        Invoke("ResetHurt", 1.5f);
        soundManager.PlayByIndex(0, 0.5f);//Reproduce el sonido [0] de la lista de sonidos del SoundManager
        //audioSource.Play();
        
        if (currentHealth <= 0)
        {
            Defeat();
            // Añadir animacion de derrotado y luego pasar al Defeat
        }
    }

    public void Defeat()
    {
        //currentHealth=maxHealth;
        //Debug.Log("Estoy derrotado  :'-(");


        SceneManager.LoadScene("GameOver");
        //Dirigir a escena de derrota
        //SceneManager.LoadScene("MainMenu");
        //
    }
    
    private void ResetHurt(){
        animator.SetBool("isHurt", false);
    }
}

public interface IDamageable
{
    void TakeDamage(int amount);
}

//https://www.youtube.com/watch?v=mkd96InZKFM&t=807s