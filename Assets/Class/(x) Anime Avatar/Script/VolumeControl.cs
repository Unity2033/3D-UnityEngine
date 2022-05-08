using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeControl : MonoBehaviour
{
    public AudioSource audioa;

    public void Set_Volume(float v)
    {
        audioa.volume = v;
    }
}
