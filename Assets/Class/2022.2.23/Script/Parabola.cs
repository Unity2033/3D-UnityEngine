using UnityEngine;

public class Parabola : MonoBehaviour
{
    // 최종적으로 이동할 기준점이 되는 게임 오브젝트
    public GameObject target;

    // 이동하는 속도 변수
    float speed = 1.0f;

    int value = 0;

    private void Start()
    {
        // Increase 함수를 0초 후에 2초 마다 반복적으로 실행시키는 함수입니다.
        InvokeRepeating("Increase", 0, 2);
    }

    void Update()
    {
        // 게임 오브젝트의 위치를 target 오브젝트의 위치로 포물선의 형태로 이동시키는 함수입니다.
        transform.position = Vector3.Slerp(transform.position, target.transform.position, speed * Time.deltaTime);

        if(value % 2 == 0) // value의 값이 짝수일 때 target의 위치를 4,2,3으로 변경합니다.
        {
            target.transform.position = new Vector3(4, 2, 3);
        }
        else // value의 값이 홀수일 때 target의 위치를 -4,2,3으로 변경합니다.
        {
            target.transform.position = new Vector3(-4, 2, 3);
        }

    }

    // value에 값을 1씩 증가시키는 함수입니다.
    void Increase()
    {
        value++;
    }
}
