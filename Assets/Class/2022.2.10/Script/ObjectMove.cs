using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMove : MonoBehaviour
{
    public GameObject Target;

    void Update()
    {
       transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, 1 * Time.deltaTime);
    }
}
