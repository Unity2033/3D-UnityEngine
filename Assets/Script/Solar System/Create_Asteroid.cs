using System.Collections;
using UnityEngine;

public class Create_Asteroid : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (true)
        {        
            yield return new WaitForSeconds(5.0f);

            GameObject t_object = Queue_Object_Pool.instance.Get_Queue();

            t_object.transform.rotation = Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
            t_object.transform.position = t_object.transform.right * 100;           
        }
    }
}
