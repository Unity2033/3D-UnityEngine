using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bicycle : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(0.1f, 0.1f, 0.1f);
    }
}
