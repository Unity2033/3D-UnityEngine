using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        if (collision.gameObject.CompareTag("Pawn"))
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

    }

    private void OnCollisionExit(Collision collision)
    {
        rigidBody.AddTorque
        (
           Vector3.up * speed,
           ForceMode.Impulse
        );
    }
}
