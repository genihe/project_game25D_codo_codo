using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogTrigger : MonoBehaviour
{
    [TextArea(3,10)]
    public string[] lines;
    private bool canActivate;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canActivate && Input.GetButtonDown("Fire1") && !DialogManager.instance.dialogBox.activeInHierarchy){
            DialogManager.instance.ShowDialog(lines);              
        }
    }

    private void OnTriggerEnter(Collider other){
        if (other.tag=="Player")
        {
            canActivate=true;
        }
    }
    private void OnTriggerExit(Collider other){
        if (other.tag=="Player")
        {
            canActivate=false;
        }
    }
}
