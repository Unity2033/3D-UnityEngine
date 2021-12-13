using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life_Cycle : MonoBehaviour
{
    // Debug.Log() : () 안에 원하는 문자를 입력하면 로그에 출력되는 함수입니다.  

    void Awake() // 스크립트가 생성될 때 최초로 호출되는 초기화 함수입니다.
    {
        Debug.Log("Awake"); // 스크립트가 비활성화된 상태로 생성되더라도 호출됩니다.    
    }

    void OnEnable() // 스크립트가 활성화 되었을 때, 게임 오브젝트가 활성활 될 때마다 호출되는 함수입니다.
    {
        Debug.Log("OnEnable"); 
    }

    void Start() // Awake -> OnEnable 이후에 단 한 번만 호출되는 함수입니다.
    {
        Debug.Log("Start"); // 스크립트가 활성화 되어야 있어야 호출됩니다.
    }

    void FixedUpdate() // 물리 연산을 하기 전에 일정한 주기로 프레임마다 호출되는 함수입니다.
    {
        Debug.Log("FixedUpdate");
    }

    void Update() // 스크립트가 활성화되었을 때 프레임마다 호출되는 함수입니다.
    {
        Debug.Log("Update"); // 환경에 따라서 실행 주기가 달라질 수 있는 함수입니다.
    }

    void LateUpdate() // 모든 업데이트 함수가 끝난 후에 실행되는 함수입니다.
    {
        Debug.Log("LateUpdate");
    }

    void OnDisable() // 스크립트가 비활성화 되었을 때, 게임 오브젝트가 비활성활 될 때마다 호출되는 함수입니다.
    {
        Debug.Log("OnDisable");
    }

    private void OnDestroy() // 게임 오브젝트가 삭제될 때 호출되는 함수입니다.
    {
        Debug.Log("OnDestroy");
    }
}
