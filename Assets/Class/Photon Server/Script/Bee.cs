using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee : MonoBehaviour
{
    private Vector3 direction;
    private GameObject target;
    private float speed = 5.0f;

    void Start()
    {
        target = GameObject.Find("Character(Clone)");

        direction = target.transform.position - transform.position;
        transform.LookAt(target.transform);
    }

    void Update()
    {
        transform.position += direction.normalized * speed * Time.deltaTime;
    }
}
