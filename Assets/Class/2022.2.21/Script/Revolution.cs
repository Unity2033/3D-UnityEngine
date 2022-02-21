using UnityEngine;

public class Revolution : MonoBehaviour
{
    public GameObject Origin; // 기준이 되는 게임 오브젝트
    public float speed = 1.0f; // 회전 속도 (변수)

    void Update()
    {
        // (회전을 하기 위한 기준점이 되는 게임 오브젝트 지정), (회전할 축 설정), (회전 속도)
        transform.RotateAround(Origin.transform.position, Vector3.down, speed * Time.deltaTime);
    }
}


