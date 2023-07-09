using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    //public int hp=10;
    //public int power=1;
    public bool isDefeat=false;
    public string currentState="Idle";
    private Transform target;
    public float chaseRange=0.5f;
    public float attackRange=0.2f;
    public float speed;
    public GameObject hero;
    public float groggyTime=2f;
    float defaultGroggyTime=2f;
    public int directionMotion=0;
    public bool isStunned=false;
    // Start is called before the first frame update
    void Start()
    {
        target=GameObject.FindGameObjectWithTag("Player").transform;
        
    }

    // Update is called once per frame
    void Update()
    {
       // if (isDefeat==false)
      //  {
            //Mover de lado a lado    
            float distance = Vector3.Distance(transform.position, target.position);

            if (currentState=="Idle" && !isStunned)
            {
                if (distance < chaseRange) 
                    currentState="Chase";
            }
            else if(currentState=="Chase")
            {
                if (distance < attackRange)
                    currentState="Attack";

                if (target.position.x > transform.position.x)
                {
                    transform.Translate(transform.right * speed * Time.deltaTime);
                }else{
                    transform.Translate(transform.right * -speed * Time.deltaTime);
                }
            }
        
            else if(currentState=="Attack")
            {
                if (distance > attackRange)
                    isStunned=true;
                    GroggyTime(defaultGroggyTime, isStunned);
                    //currentState="Chase";
            }
       // }

    }

    public void GroggyTime(float groggy, bool stunned){
        if (stunned)
        {
            if (groggyTime>0)
            {
                groggyTime-=Time.deltaTime;
            }else{
                isStunned=false;
                currentState="Idle";
                groggyTime=defaultGroggyTime;
            }
        }
       
    }

}


/*
            timer start
            timer finish
                ataque 1
                atacke 2
                caminar (seguir a cactus)
            
            caminar
        */
