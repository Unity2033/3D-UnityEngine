using System.Collections;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public string [] Planet;

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
