using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 2.5f;
    public Transform destination;

    void Update()
    {
        transform.position = Vector3.MoveTowards
        (
            transform.position, destination.position, Time.deltaTime * speed
        );
    }

    private void OnBecameInvisible()
    {
        transform.position = new Vector3(10, 1, 0);
    }

}
