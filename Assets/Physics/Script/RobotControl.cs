using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEditor;
using UnityEngine;

public class RobotControl : MonoBehaviour
{
    public float speed = 2.5f;
    public float radius = 2.0f;

    private Vector3 direction;
    private Rigidbody rigidBody;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    public void Update()
    {
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.z = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        Collider [ ] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider element in colliders)
        {
            if (element.tag == "Billiard Ball")
            {
                element.GetComponent<BallControl>().SendMessage("AddTorqueMessage");
            }
        }

        rigidBody.transform.position += direction.normalized * speed * Time.fixedDeltaTime;
    }

}
