using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create : MonoBehaviour
{
    public GameObject Prefab;

    public void GenericCreate()
    {
        Instantiate(Prefab, new Vector3(0, 5, 0), Quaternion.identity);
    }

    public void PoolCreate()
    {
        ObjectPool.objpool.GetQueue();
    }
}


