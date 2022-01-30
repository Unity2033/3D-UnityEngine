using UnityEngine;
using System.Collections.Generic;

public class Queue_Object_Pool : MonoBehaviour
{
    public static Queue_Object_Pool instance;

    public GameObject Prefab;

    public Queue<GameObject> m_queue = new Queue<GameObject>();

    private void Start()
    {
        instance = this;

        for (int i = 0; i <= 5; i++)
        {
            GameObject t_object = Instantiate(Prefab, Vector3.zero, Quaternion.identity);
            m_queue.Enqueue(t_object);
            t_object.SetActive(false);
        }
    }

    public void Insert_Queue(GameObject p_object)
    {
        m_queue.Enqueue(p_object);
        p_object.transform.position = new Vector3(0, 0, 0);
        p_object.transform.rotation = new Quaternion(0, 0, 0,0);

        p_object.SetActive(false);
    }

    public GameObject Get_Queue()
    {
        GameObject t_object = m_queue.Dequeue();
        t_object.SetActive(true);
        return t_object;
    }
}
