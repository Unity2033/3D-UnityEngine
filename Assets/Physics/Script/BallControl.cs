using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallControl : MonoBehaviour
{
    Rigidbody rigidBody;

    [SerializeField] float speed = 5.0f;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    public void AddForceMessage()
    {
        rigidBody.AddForce
        (
            Vector3.forward * speed,
            ForceMode.Impulse
       );      
    }

    public void AddTorqueMessage()
    {
        rigidBody.AddTorque
        (
            Vector3.up * speed,
            ForceMode.Force
        );
    }

    // 물리적인 충돌을 했을 때 동작하는 함수입니다.
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

    // 물리적인 충돌을 하고 있을 때 동작하는 함수입니다.
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Billiard Ball"))
        {
            collision.gameObject.GetComponent<Rigidbody>().useGravity = false;
        }
    }

    // 물리적인 충돌을 벗어났을 때 동작하는 함수입니다.
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Billiard Ball"))
        {
            collision.gameObject.GetComponent<Rigidbody>().useGravity = true;
        }
    }
}
