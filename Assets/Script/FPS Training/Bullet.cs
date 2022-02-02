using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public string[] Planet;
    Character_Control Origin;

    private void Start()
    {
        Origin = GameObject.Find("Character").GetComponent<Character_Control>();
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
