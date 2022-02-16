using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSystem : MonoBehaviour
{
    AudioSource audiosource;
    public AudioClip audioclip;

    private void Start()
    {
        audiosource = GetComponent<AudioSource>();
        audiosource.clip = audioclip;
    }

    public void PlaySound()
    {
        audiosource.Play();
    }

    public void StopSound()
    {
        audiosource.Stop();
    }
}
