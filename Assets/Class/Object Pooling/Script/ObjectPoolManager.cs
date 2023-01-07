using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPoolManager : MonoBehaviour
{
    [SerializeField] GameObject beePrefab;

    private IObjectPool<Bee> beePool;

    void Awake()
    {
        beePool = new ObjectPool<Bee>
        (
            CreateBee,
            OnGetBee,
            OnReleaseBee,
            OnDestroyBee,
            maxSize : 20       
       );
    }

    private void Start()
    {
        StartCoroutine(GenerateScheduleCycle());
    }

    IEnumerator GenerateScheduleCycle()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);

            beePool.Get();
        }
    }


    private Bee CreateBee()
    {
        Bee bee = Instantiate(beePrefab,new Vector3(0f,0.75f,0.3f), Quaternion.identity).GetComponent<Bee>();
        bee.SetManaged(beePool);
        return bee;
    }

    private void OnGetBee(Bee bee)
    {
        bee.gameObject.SetActive(true);
    }

    private void OnReleaseBee(Bee bee)
    {
        bee.gameObject.SetActive(false);
    }

    private void OnDestroyBee(Bee bee)
    {
        Destroy(bee);
    }
}
