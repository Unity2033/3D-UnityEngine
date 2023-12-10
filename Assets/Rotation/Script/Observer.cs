using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    public GameObject sun;
    public float speed = 1.0f;

    public IEnumerator Start()
    {
        while (true)
        {
            transform.RotateAround
            (
                sun.transform.position,
                Vector3.down,
                speed * Time.deltaTime
            );

            yield return null;
        }
    }
}


