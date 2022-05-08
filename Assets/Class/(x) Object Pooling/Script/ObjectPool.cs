using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool objpool;

    // 오브젝트 풀에 담을 게임 오브젝트를 설정합니다.
    public GameObject obj;

    // 게임 오브젝트를 담을 수 있는 자료구조 Queue를 생성합니다.
    public Queue<GameObject> mqueue = new Queue<GameObject>();

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
