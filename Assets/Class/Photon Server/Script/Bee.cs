using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee : MonoBehaviour
{
    private GameObject target;
    private Vector3 direction;

    void Start()
    {
        target = GameObject.Find("Character(Clone)");

        direction = target.transform.position - transform.position;
        transform.LookAt(target.transform);

        Destroy(gameObject, 5);
    }

    void Update()
    {
        transform.position += direction * 1 * Time.deltaTime;
    }
}
