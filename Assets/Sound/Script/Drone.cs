using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour
{
    public float speed = 55;

    private void Start()
    {
        InvokeRepeating("NewPosition", 5, 5);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);   
    }

    public void NewPosition()
    {
        transform.position = new Vector3
        (
             Random.insideUnitCircle.x * 5,
             Random.insideUnitCircle.y * 5,
             250
        );
    }
}
