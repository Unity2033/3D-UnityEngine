using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Pool;

public class ObjectPoolManager : MonoBehaviour
{
    [SerializeField] Button sprayButton;
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
            maxSize : 5       
       );
    }

    private void Start()
    {
        InvokeRepeating(nameof(GenerateScheduleCycle), 1, 1);

        sprayButton.GetComponent<Button>().onClick.AddListener(ObjectRelease);
    }

    public void GenerateScheduleCycle()
    {
         beePool.Get();          
    }

    private Bee CreateBee()
    {
        Bee bee = Instantiate
        (
            beePrefab, Random.onUnitSphere * 2.5f, Quaternion.identity
        ).GetComponent<Bee>();

        int index = bee.name.IndexOf("(Clone)");

        if (index > 0)
        {
            bee.name = bee.name.Substring(0, index);
        }

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

    public void ObjectRelease()
    {    
        beePrefab = GameObject.Find("FantasyBee");

        beePrefab.GetComponent<Bee>().Release();    
    }
}
