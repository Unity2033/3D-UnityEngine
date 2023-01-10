using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Bee : MonoBehaviour
{
    public IObjectPool<Bee> managedPool;

    public void SetManaged(IObjectPool<Bee> pool)
    {
        managedPool = pool;
    }

    public void Release()
    {
        managedPool.Release(this);
    }
}
