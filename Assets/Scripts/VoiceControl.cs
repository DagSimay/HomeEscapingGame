using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceControl : MonoBehaviour
{
    public EnemyRoute enemyRoute;
    public Hiding hiding;
    private AudioSource audioSource;
    public AudioClip normalVoice;
    public AudioClip hideVoice;
    public AudioClip holdingVoice;
    public AudioClip afterholdingVoice;
    public AudioClip escapeVoice;
    private float waitTimer = 0;
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        choosePlayVoice(normalVoice);
    }

    
    void Update()
    {
        if (hiding.isHide==true)
        {
            choosePlayVoice(hideVoice);
           // if (Vector3.Distance(enemyRoute.targets[1],enemyRoute.gameObject.transform.position) < 0.1f && Vector3.Distance(hiding.hidingPositions[3],gameObject.transform.position) < 0.1f )
            
        }
        else
        {
            choosePlayVoice(normalVoice);
        }
    }
    
    void choosePlayVoice(AudioClip clip)
    {
        
        if (audioSource.clip != clip)
        {
            audioSource.clip = clip;
            audioSource.Play();
            
            if (clip == normalVoice || clip == hideVoice || clip == escapeVoice)
            {
                audioSource.loop = true;
            }
            else
            {
                audioSource.loop = false;
            }
            
            if (clip == holdingVoice)
            {
                bool isPlaying = true;
                if (isPlaying)
                {
                    waitTimer += Time.deltaTime;
                    if (waitTimer >= 4f)
                    {
                        isPlaying = false;
                    }
                }
                waitTimer = 0;
                choosePlayVoice(afterholdingVoice);
            }
        }
    }
}
