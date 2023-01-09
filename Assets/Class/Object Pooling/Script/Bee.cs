using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Bee : MonoBehaviour
{
    private GameObject target;
    [SerializeField] float speed = 3.0f;

    public IObjectPool<Bee> managedPool;

    private void Start()
    {
        target = GameObject.Find("MARMO MIDDLE");
    }

    public void SetManaged(IObjectPool<Bee> pool)
    {
        managedPool = pool;
    }

    public void Release()
    {
        managedPool.Release(this);
    }
}
