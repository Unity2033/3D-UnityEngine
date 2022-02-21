using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateContainer : MonoBehaviour
{
    GameObject Container;


    private void Start()
    {
        InvokeRepeating("Create", 0, 5);
    }

    void Create()
    {
        Container = Resources.Load<GameObject>("Container");
        Instantiate(Container);
    }
}
