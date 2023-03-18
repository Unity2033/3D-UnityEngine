using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delete : MonoBehaviour
{
    int random = Random.Range(1, 5);

    void Start()
    {
        Destroy(gameObject, random);
    }
}

