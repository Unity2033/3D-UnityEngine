using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsControl : MonoBehaviour
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
        direction.y = rigidBody.velocity.y;

        if (direction.y >= 0.5f)
        {
            direction.y -= rigidBody.velocity.y;
        }

        rigidBody.velocity = direction.normalized * speed * Time.deltaTime;
    }

    // 물리적인 충돌을 했을 때 동작하는 함수입니다.
    private void OnCollisionEnter(Collision collision)
    {

    }

    // 물리적인 충돌을 하고 있을 때 동작하는 함수입니다.
    private void OnCollisionStay(Collision collision)
    {
       
    }

    // 물리적인 충돌을 벗어났을 때 동작하는 함수입니다.
    private void OnCollisionExit(Collision collision)
    {
      
    }
}
