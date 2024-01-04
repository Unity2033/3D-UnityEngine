using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public IEnumerator Start()
    {
        transform.LookAt(Camera.main.transform);

        yield return new WaitForEndOfFrame();
    }
}


