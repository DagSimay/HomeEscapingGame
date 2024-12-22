using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceControl : MonoBehaviour
{
    public Hiding hiding;
    private AudioSource audioSource;
    public AudioClip normalVoice;
    public AudioClip hideVoice;
    
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        choosePlayVoice(normalVoice);
    }

    
    void Update()
    {
        if (hiding.isHide == true)
        {
            choosePlayVoice(hideVoice);
        }
        else
        {
            choosePlayVoice(normalVoice);
        }
    }
    
    public void choosePlayVoice(AudioClip clip)
    {
        
        if (audioSource.clip != clip)
        {
            audioSource.clip = clip;
            audioSource.Play();
        }
    }
}
