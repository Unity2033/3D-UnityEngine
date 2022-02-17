using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObject : MonoBehaviour
{
    public GameObject cube;
    GameObject obj;

    void Start()
    {   
        Instantiate(cube, new Vector3(0,1,0), Quaternion.identity);
        obj = GameObject.Find("Cube(Clone)");
    }

    void Update()
    {
        if(Input.GetKey("a"))
        {
            Destroy(obj);
        }
    }
}
