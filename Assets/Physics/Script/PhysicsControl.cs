using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PhysicsControl : MonoBehaviour
{
    Rigidbody rigidBody;
    [SerializeField] float speed = 1.0f;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    public void AddForceMessage(Vector3 direction)
    {
        rigidBody.AddForce
        (
            direction * speed,
            ForceMode.Force
       );      
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Pillar"))
        {
            var result = Vector3.Reflect
            (
                 transform.position.normalized, 
                 collision.contacts[0].normal
            );

            rigidBody.velocity = result * Mathf.Max(speed, 0f);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
         // rigidBody.Sleep(); 
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Pillar"))
        {
            rigidBody.AddTorque
            (
                Vector3.up * speed,
                ForceMode.Impulse
            );
        }
    }
}
