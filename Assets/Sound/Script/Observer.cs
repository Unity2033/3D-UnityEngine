using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    public Transform sun;
    public float speed = 25.0f;

    private void Update()
    {
          transform.RotateAround
          (
              sun.position,
              Vector3.down,
              speed * Time.deltaTime
          );
    }
}


