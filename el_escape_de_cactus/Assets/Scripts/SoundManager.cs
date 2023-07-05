using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] audios;
    private AudioSource controlAudio;

    private void Awake() { 
        controlAudio = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update

    void Start() { }

    // Update is called once per frame
    void Update() { }

    public void PlayByIndex(int index, float volume){
        controlAudio.PlayOneShot (audios [index], volume);
    }
    public void PlayInLoopByIndex(int index, float volume){
        controlAudio.loop = true;
        controlAudio.clip = audios[index];
        controlAudio.volume = volume;
        controlAudio.Play();
    }

    public void Stop(){
        if(controlAudio.isPlaying){
            controlAudio.Stop();
        }
    }
}
