using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] sfxClips;
  
    [SerializeField]
    private AudioSource sfxSource;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AudioPlay(int num)
    {
        sfxSource.clip = sfxClips[num];
        if (sfxSource.isPlaying == false)
        {
            sfxSource.Play();
        }
        else return;
    }
}
