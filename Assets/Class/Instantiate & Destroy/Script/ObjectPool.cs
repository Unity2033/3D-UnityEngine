using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    // 자료구조
    // Queue : 가장 먼저 들어온 데이터가 가장 먼저 나가는 구조입니다.
    public static ObjectPool objpool;

    // 오브젝트 풀에 담을 게임 오브젝트를 설정합니다.
    public GameObject prefab;

    // 게임 오브젝트를 담을 수 있는 자료구조 Queue를 생성합니다.
    public Queue<GameObject> queue = new Queue<GameObject>();

    void Start()
    {
        objpool = this;

        for(int i =0; i < 10; i++)
        {
            GameObject tempPrefab = Instantiate(prefab, new Vector3(0, 5, 0), Quaternion.identity);
            queue.Enqueue(tempPrefab);
            tempPrefab.gameObject.SetActive(false);

        }
    }

    public void InsertQueue(GameObject pobj)
    {
        queue.Enqueue(pobj);
        pobj.gameObject.SetActive(false);
    }

    public GameObject GetQueue()
    {
        GameObject tempPrefab = queue.Dequeue();
        tempPrefab.gameObject.SetActive(true);

        return tempPrefab;
    }

}
