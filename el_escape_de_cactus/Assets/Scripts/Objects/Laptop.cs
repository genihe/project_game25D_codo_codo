using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Laptop : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    private GameObject objectChild;
    [SerializeField] bool OnOffScreen=false;  

    // Start is called before the first frame update
    void Start()
    {
        //objectChild=transform.GetChild(0).gameObject;
        //videoPlayer=objectChild.GetComponent<VideoPlayer>();
        //Debug.Log(objectChild.name);
        Debug.Log("Video Player : "+videoPlayer);
    }

    // Update is called once per frame
    void Update() {}


    private void OnCollisionEnter(Collision other){
        if (other.gameObject.tag=="Player")
        {
            OnOffScreen=true;
            ScreenOn();
        }
    }
    public void ScreenOn(){
        if (OnOffScreen)
        {
            //Debug.Log("Enciendo pantalla");
            if (!videoPlayer.isPlaying){
                videoPlayer.Play();
            }
        } 
    }
}
