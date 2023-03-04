using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    private Vector3 direction = Vector3.forward;

    void Update()
    {
        transform.Translate(direction * Time.deltaTime);

        if (transform.position.x >= 2.5f)
        {
            direction = Vector3.forward;
            transform.localScale = new Vector3(3.5f, 3.5f, 3.5f);
        }
        else if (transform.position.x <= -2.5f)
        {
            direction = Vector3.back;
            transform.localScale = new Vector3(3.5f, 3.5f, -3.5f);
        }
    }

}
