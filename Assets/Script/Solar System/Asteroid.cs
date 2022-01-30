using System.Collections;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public string [] Planet;
    Airplane_Control Origin;

    private void Start()
    {
        Origin = GameObject.Find("War Plane").GetComponent<Airplane_Control>();
    }

    private void Update()
    {
        if(Vector3.Distance(transform.position, Origin.transform.position) >= 100)
        {
            Queue_Object_Pool.instance.Insert_Queue(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < Planet.Length; i++)
        {
            if (other.gameObject.tag == Planet[i])
            {            
                Queue_Object_Pool.instance.Insert_Queue(gameObject);              
            }
        }
    }
}
