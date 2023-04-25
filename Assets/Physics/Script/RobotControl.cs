using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEditor;
using UnityEngine;

public class RobotControl : MonoBehaviour
{
    public float speed = 2.5f;
    public float radius = 1.5f;

    private Vector3 direction;
    private Rigidbody rigidBody;

    private void Start()
    {
        Cursor.visible = false;                   
        Cursor.lockState = CursorLockMode.Locked;   

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
            if (element.CompareTag("Billiard Ball"))
            {
                element.GetComponent<PhysicsControl>().AddForceMessage(rigidBody.transform.forward);
            }
        }

        rigidBody.rotation = rigidBody.rotation * Quaternion.Euler(0, Input.GetAxis("Mouse X"), 0);

        rigidBody.transform.position += rigidBody.transform.TransformDirection
        (
            direction.normalized * speed *  Time.fixedDeltaTime
        );
    }

}
