using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create : MonoBehaviour
{
    public GameObject prefab;

    public void GenericCreate()
    {
        Delay.action();

        Instantiate 
        (
            prefab, 
            new Vector3(0, -1.25f, 0), 
            prefab.transform.rotation
        ).AddComponent<Delete>();
    }
}






