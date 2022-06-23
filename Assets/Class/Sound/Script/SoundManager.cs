using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip [] audioClip;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void SoundCall(string name)
    {
        switch(name)
        {
            case "Siren" : audioSource.clip = audioClip[0];
                audioSource.Play();
                break;
            case "Explosion" : audioSource.clip = audioClip[1];
                audioSource.Play();
                break;
            case "Magic": audioSource.clip = audioClip[2];
                audioSource.Play();
                break;
        }
    }

    public void VolumeControl(float volume)
    {
        audioSource.volume = volume;
    }


}
