using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip [] sound;

    private void OnGUI()
    {
        if (GUI.Button(new Rect(20, 25, 200, 30), "Search Button"))
        {
            Transform observer = GameObject.Find("Drone").transform;

            AudioSource.PlayClipAtPoint(sound[0], observer.position);
        }

        if (GUI.Button(new Rect(20, 80, 200, 30), "Connect Button"))
        {
            GetComponent<AudioSource>().PlayOneShot(sound[1]);
        }
    }
}
