using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControll : MonoBehaviour
{
    bool condition;
    public float speed;

    Rigidbody rigid;
    Vector3 dir;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        dir.x = Input.GetAxis("Horizontal");
        dir.z = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Space) && condition == true)
        {
            // AddForce : 객체에 일정한 힘을 가하는 함수입니다.
            rigid.AddForce(new Vector3(0, 200, 0));
            condition = false;
        }

    }

    private void FixedUpdate()
    {
        rigid.MovePosition
            (
              rigid.position +
              dir *
              speed *
              Time.deltaTime
            );
    }

    // 물리적인 충돌을 했을 때 동작하는 함수입니다.
    private void OnCollisionEnter(Collision collision)
    {
        condition = true;
    }

    // 물리적인 충돌을 하고 있을 때 동작하는 함수입니다.
    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("Stay");
    }

    // 물리적인 충돌을 벗어났을 때 동작하는 함수입니다.
    private void OnCollisionExit(Collision collision)
    {
        condition = false;
    }

    // OnTrigger : 물리적인 충돌을 하지 않고 충돌 처리를 하는 함수입니다.

    // 물리적인 충돌을 하지 않고 충돌을 했을 때 동작하는 함수입니다.
    private void OnTriggerEnter(Collider other)
    {
        gameObject.SetActive(false);
    }

    // 물리적인 충돌을 하지 않고 충돌을 하고 있을 때 동작하는 함수입니다.
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Trigger Stay");
    }

    // 물리적인 충돌을 하지 않고 충돌을 벗어났을 때 동작하는 함수입니다.
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Trigger Exit");
    }
}
