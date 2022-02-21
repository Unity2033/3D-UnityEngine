using UnityEngine;

public class MoveContainer : MonoBehaviour
{
    public float speed = 1.0f;

    void Update()
    {
        // z 방향으로 speed * Time.deltaTime 만큼 계속 이동합니다.
        transform.Translate(0, 0, speed * Time.deltaTime);
    }


    // 물리적인 충돌을 하였을 때 호출되는 함수
    private void OnCollisionEnter(Collision collision)
    {
        // 게임 오브젝트의 태그가 Wall 인 오브젝트와 충돌이 되었을 때 이벤트 처리하도록 설정합니다.
        if(collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
