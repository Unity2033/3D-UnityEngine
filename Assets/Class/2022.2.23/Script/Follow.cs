using UnityEngine;

public class Follow : MonoBehaviour
{
    // 따라다니기 위한 게임 오브젝트를 설정합니다.
    public GameObject target;

    // 카메라의 이동 속도
    public float speed = 10; 

    // LateUpdate는 어떤 게임 오브젝트를 따라다닐 때 사용합니다.
    private void LateUpdate()
    {
        // 방향 변수 dir을 생성하여 target 오브젝트의 기준으로 방향과 위치를 설정합니다.
        Vector3 dir = new Vector3(target.transform.position.x, target.transform.position.y + 2, target.transform.position.z - 3.5f);

        // 카메라 오브젝트가 부드러운 이동을 할 수 있도록 선형 보간법을 사용합니다.
        // 카메라의 위치에서 dir 방향 변수에 설정된 값까지 자연스럽게 이동하도록 설정합니다.
        transform.position =  Vector3.Lerp(transform.position, dir, speed * Time.deltaTime);
    }

}
