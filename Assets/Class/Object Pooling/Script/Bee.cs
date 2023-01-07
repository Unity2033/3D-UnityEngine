using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Bee : MonoBehaviour
{
    [SerializeField] float speed = 3.0f;

    private IObjectPool<Bee> managedPool;

    public void SetManaged(IObjectPool<Bee> pool)
    {
        managedPool = pool;
    }

    private void Update()
    {
        transform.position += new Vector3(0, 0.01f, 0f);

        //if (Screen.height >= 5)
        //{
        //    managedPool.Release(this);
        //    transform.position = new Vector3(0, 0.0f, 0f);
        //}
    }
}
