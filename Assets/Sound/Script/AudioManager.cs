using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioClip [ ] audioClip;
    [SerializeField] AudioSource audioSource;

    public void Search()
    {
        Drone drone = GameObject.Find("Drone").GetComponent<Drone>();

        drone.transform.Find("Canvas").gameObject.SetActive(true);

        AudioSource.PlayClipAtPoint(audioClip[0], drone.transform.position);
    }

    public void Signal()
    {
        audioSource.PlayOneShot(audioClip[1]);
    }
}
