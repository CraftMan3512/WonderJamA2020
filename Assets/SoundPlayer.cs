using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    
    public static double GlobalVolume = 1;

    [Range(0,1)]
    public double globalVolumeSet;

    public bool SetGlobalVol = false;
    private AudioSource source;

    public static AudioClip[] songs;
    
    // Start is called before the first frame update
    void Start()
    {

        DontDestroyOnLoad(gameObject);
        source = GetComponent<AudioSource>();
        if (SetGlobalVol) GlobalVolume = globalVolumeSet;

    }

    private void Awake()
    {
        songs = new AudioClip[]{Resources.Load<AudioClip>("Music/Forest"),Resources.Load<AudioClip>("Music/Champ"),Resources.Load<AudioClip>("Music/Desert"),Resources.Load<AudioClip>("Music/Jungle"),Resources.Load<AudioClip>("Music/Roches")};
    }

    public void SetMusic(AudioClip clip, bool startPlaying = true)
    {

        if (clip.name != source.clip.name)
        {
            
            if (source.isPlaying) source.Stop();
            source.clip = clip;
            if (startPlaying) source.Play();   
            
        }


    }

    public void PlaySFX(AudioClip clip)
    {
        
        source.PlayOneShot(clip,2);
        
    }
}
