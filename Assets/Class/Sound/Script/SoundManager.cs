using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioClip [] audioClip;
    [SerializeField] AudioSource audioSource;

    public void SoundCall(int count)
    {
        audioSource.PlayOneShot(audioClip[count]);
    }

    public void Volume(float volume)
    {
        audioSource.volume = volume;
    }
}


