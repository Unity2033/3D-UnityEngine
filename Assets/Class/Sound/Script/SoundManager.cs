using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioClip [] audioClip;
    [SerializeField] AudioSource soundSource;
    [SerializeField] AudioSource effectSource;

    private void Start()
    {
        soundSource.spatialBlend = 1;
    }

    public void SoundCall(int count)
    {
        effectSource.PlayOneShot(audioClip[count]);
    }

    public void Volume(float volume)
    {
        soundSource.volume = volume;
    }
}


