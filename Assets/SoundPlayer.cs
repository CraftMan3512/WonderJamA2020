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
    
    // Start is called before the first frame update
    void Start()
    {

        DontDestroyOnLoad(gameObject);
        source = GetComponent<AudioSource>();
        if (SetGlobalVol) GlobalVolume = globalVolumeSet;

    }

    public void SetMusic(AudioClip clip, bool startPlaying = true)
    {

        if (source.isPlaying) source.Stop();
        source.clip = clip;
        if (startPlaying) source.Play();
        

    }

    public void PlaySFX(AudioClip clip)
    {
        
        source.PlayOneShot(clip,2);
        
    }
}
