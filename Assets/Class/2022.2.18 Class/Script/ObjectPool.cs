using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool objpool;

    public GameObject obj;

    public Queue<GameObject> mqueue = new Queue<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        objpool = this;

        for(int i = 0; i < 10; i++)
        {
            GameObject tobj = Instantiate(obj, Vector3.zero, Quaternion.identity);
            mqueue.Enqueue(tobj);
            tobj.gameObject.SetActive(false);
        }
    }

    public void InsertQueue(GameObject pobj)
    {
        mqueue.Enqueue(pobj);
        pobj.gameObject.SetActive(false);
    }

    public GameObject GetQueue()
    {
        GameObject tobj =  mqueue.Dequeue();
        tobj.gameObject.SetActive(true);

        return tobj;
    }
  
}
