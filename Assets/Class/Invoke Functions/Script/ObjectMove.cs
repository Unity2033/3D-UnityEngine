using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMove : MonoBehaviour
{
    public GameObject target;
    private float speed = 1.0f;

    void Start()
    {
        // InvokeRepeating 함수는 일정 시간을 지정하고 일정 시간 후 반복적으로 함수를 호출할 때 사용합니다.
        InvokeRepeating("Position", 1, 3);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // CancelInvoke 함수는 설정한 인보크 함수를 취소시키는 함수입니다.
            CancelInvoke("Position");
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            // Invoke 함수는 일정 시간을 지정하고 일정 시간 후 함수를 호출할 때 사용합니다.
            Invoke("Paint", 3);
        }

        // 매개 변수에는 현재 위치, 목표 위치, 속도를 설정합니다. 
        transform.position = Vector3.MoveTowards
        (
            transform.position, 
            target.transform.position, 
            speed * Time.deltaTime
        );
    }

    public void Paint()
    {
        switch (Random.Range(0, 3))
        {
            // 게임 오브젝트에 스크립트를 부착하고 현재 컴포넌트에 Renderer 컴포넌트가 있으면 사용할 수 있습니다.
            case 0 : gameObject.GetComponent<Renderer>().material.color = Color.red;
                break;
            case 1 : gameObject.GetComponent<Renderer>().material.color = Color.black;
                break;
            case 2 : gameObject.GetComponent<Renderer>().material.color = Color.yellow;
                break;
        }
    }
    
    public void Position()
    {
        target.transform.position = new Vector3(Random.Range(0, 5), 2, Random.Range(0, 5));
        Debug.Log("동작");
    }
}
