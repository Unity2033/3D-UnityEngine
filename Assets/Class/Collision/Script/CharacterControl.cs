using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    public float speed;

    Rigidbody rigid;
    Vector3 direction;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        direction.x = Input.GetAxis("Horizontal");
        direction.z = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
         rigid.MovePosition
         (
              rigid.position + direction.normalized *
              speed * Time.deltaTime
         );
    }

    // 물리적인 충돌을 했을 때 동작하는 함수입니다.
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Fence"))
        {
            ContactPoint cp = collision.GetContact(0);
            Vector3 dir = transform.position - cp.point; // 접촉지점에서부터 탄위치 의 방향
            rigid.AddForce(dir.normalized * 300f);
        }
    }

    // 물리적인 충돌을 하고 있을 때 동작하는 함수입니다.
    private void OnCollisionStay(Collision collision)
    {
       
    }

    // 물리적인 충돌을 벗어났을 때 동작하는 함수입니다.
    private void OnCollisionExit(Collision collision)
    {
      
        if (collision.gameObject.CompareTag("Fence"))
        {
            
        }
    }
}
