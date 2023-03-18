using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    Vector3 direction;
    Rigidbody rigidBody;
    [SerializeField] float speed = 5.0f;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        direction.x = Input.GetAxis("Horizontal");
        direction.z = Input.GetAxis("Vertical");    
    }

    private void FixedUpdate()
    {
        rigidBody.AddForce
        (
            direction.normalized * speed * Time.deltaTime,
            ForceMode.Impulse        
        );
    }

    // 물리적인 충돌을 했을 때 동작하는 함수입니다.
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Pawn"))
        {
            var result = Vector3.Reflect
                (
                  direction.normalized, 
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
