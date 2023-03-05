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
            prefab.transform.position,
            prefab.transform.rotation
        );
    }
}






