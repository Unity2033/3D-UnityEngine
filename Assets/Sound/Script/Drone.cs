using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour
{
    public float speed = 55;
    public Vector3 direction;

    private void Start()
    {
        direction = transform.position;

        InvokeRepeating("NewPosition", 5, 5);
    }

    void Update()
    {
        transform.Translate
        (
            Vector3.forward * speed * Time.deltaTime
        );   
    }

    public void NewPosition()
    {
        transform.position = direction;
        transform.Find("Canvas").gameObject.SetActive(false);
    }
}
