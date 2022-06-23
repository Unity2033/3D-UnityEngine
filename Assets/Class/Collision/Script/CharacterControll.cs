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
            // AddForce : ��ü�� ������ ���� ���ϴ� �Լ��Դϴ�.
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

    // �������� �浹�� ���� �� �����ϴ� �Լ��Դϴ�.
    private void OnCollisionEnter(Collision collision)
    {
        condition = true;
    }

    // �������� �浹�� �ϰ� ���� �� �����ϴ� �Լ��Դϴ�.
    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("Stay");
    }

    // �������� �浹�� ����� �� �����ϴ� �Լ��Դϴ�.
    private void OnCollisionExit(Collision collision)
    {
        condition = false;
    }

    // OnTrigger : �������� �浹�� ���� �ʰ� �浹 ó���� �ϴ� �Լ��Դϴ�.

    // �������� �浹�� ���� �ʰ� �浹�� ���� �� �����ϴ� �Լ��Դϴ�.
    private void OnTriggerEnter(Collider other)
    {
        gameObject.SetActive(false);
    }

    // �������� �浹�� ���� �ʰ� �浹�� �ϰ� ���� �� �����ϴ� �Լ��Դϴ�.
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Trigger Stay");
    }

    // �������� �浹�� ���� �ʰ� �浹�� ����� �� �����ϴ� �Լ��Դϴ�.
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Trigger Exit");
    }
}
