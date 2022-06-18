using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropObject : MonoBehaviour
{
    Rigidbody rigid;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    private void OnMouseDrag()
    {
        rigid.isKinematic = true;

        // ���콺�� ��ġ�� �����մϴ�.
        Vector3 mouseposition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(gameObject.transform.position).z);

        //���콺 ��ǥ�� ScreenToWorldPoint�� �����Ͽ� ������Ʈ�� ��ġ�� �����մϴ�.
        Vector3 objposition = Camera.main.ScreenToWorldPoint(mouseposition);

        transform.position = objposition;
    }

    private void OnMouseUp()
    {
        rigid.isKinematic = false;
    }
}



