using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    
    [SerializeField] private AudioSource bgmAudioSource;
    [SerializeField] private AudioSource sfxAudioSource;
    
    private float bgmVolume = 0.5f;
    private float sfxVolume = 0.5f;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        bgmAudioSource.volume = bgmVolume;
        sfxAudioSource.volume = sfxVolume;
    }
    
    public void PlaySFX(AudioClip sfxClip)
    {
        if (sfxAudioSource != null && sfxClip != null)
        {
            sfxAudioSource.PlayOneShot(sfxClip, sfxVolume);
        }
    }
}
