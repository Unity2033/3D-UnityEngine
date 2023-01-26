using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioClip [] audioClip;
    [SerializeField] AudioSource soundSource;
    [SerializeField] AudioSource effectSource;

    public void SoundCall(int count)
    {
        effectSource.PlayOneShot(audioClip[count]);
    }

    public void Volume(float volume)
    {
        soundSource.volume = volume;
    }

}


