using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvokeFunction : MonoBehaviour
{
    void Start()
    {
        // Invoke 함수는 일정 시간을 지정하고 일정 시간 후 함수를 호출할 때 사용합니다.
        Invoke("Call", 3);

        // InvokeRepeating 함수는 일정 시간을 지정하고 일정 시간 후 반복적으로 함수를 호출할 때 사용합니다.
        InvokeRepeating("RepeatCall", 1, 3);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            // CancelInvoke 함수는 인보크 함수를 취소시키는 함수입니다.
            CancelInvoke("RepeatCall");
        }
    }

    public void Call()
    {
        Debug.Log("Invoke 함수 호출");
    }

    public void RepeatCall()
    {
        Debug.Log("Invoke 함수 반복 호출");
    }

}
