using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    
    public AudioSource audioSource;
    
    public AudioClip journeyBGM;
    public AudioClip campfireBGM;

    private void Awake()
    {
        Instance = this;
    }

    public void PlayCampfireBGM()
    {
        audioSource.clip = campfireBGM;
        audioSource.Play();
    }
    
    public void PlayJourneyBGM()
    {
        audioSource.clip = journeyBGM;
        audioSource.Play();
    }
}
