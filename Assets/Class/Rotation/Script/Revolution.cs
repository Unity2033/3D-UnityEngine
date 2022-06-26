using UnityEngine;

public class Revolution : MonoBehaviour
{
    public GameObject origin; // 기준 축이 되는 게임 오브젝트
    public float speed = 1.0f; // 회전 속도

    void Update()
    {
        // (회전을 하기 위한 기준점이 되는 게임 오브젝트 지정), (회전할 축 설정), (회전 속도)
        transform.RotateAround(origin.transform.position, Vector3.down, speed * Time.deltaTime);
    }
}


