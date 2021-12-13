using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour
{
    public GameObject Belt;
    public Transform Point;
    public float speed;

    private void OnTriggerStay(Collider other)
    {
        other.transform.position = Vector3.MoveTowards
           (
            other.transform.position,
            Point.position, 
            speed * Time.deltaTime
           );
    }
}
