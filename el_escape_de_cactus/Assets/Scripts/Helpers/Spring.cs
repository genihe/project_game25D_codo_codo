using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    public PlayerController playerControl;
    [SerializeField] private float springForce;
    private SoundManager soundManager;

    private void Awake()
    {
        soundManager = FindObjectOfType<SoundManager>();
    }
    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update() { }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerAttack")
        {
            soundManager.PlayByIndex(7,0.6f); //Index [7] sonido de rebote
            //Debug.Log("RESORTE: Salta Player");
            playerControl.Bounce(springForce);
        }
    }
}
