using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create : MonoBehaviour
{
    public GameObject prefab;
    public Transform [] randomPosition;

    public void GenericCreate()
    {
        Delay.action();

        Instantiate
        (
            prefab, 
            randomPosition[Random.Range(0,4)].position, 
            Quaternion.identity
        );
    }
}






