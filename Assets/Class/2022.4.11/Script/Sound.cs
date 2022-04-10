using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sound : MonoBehaviour
{
    AudioSource source;
    public AudioClip[] album;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            source.clip = album[0];
            source.Play();
        }
        else if(Input.GetKeyDown(KeyCode.F2))
        {
            source.clip = album[1];
            source.Play();
        }
        else if (Input.GetKeyDown(KeyCode.F3))
        {
            source.clip = album[2];
            source.Play();
        }
        else if (Input.GetKeyDown(KeyCode.F4))
        {
            source.clip = album[3];
            source.Play();
        }
        else if (Input.GetKeyDown(KeyCode.F5))
        {
            SceneManager.LoadScene("2022.4.11.new");
        }


    }
}
