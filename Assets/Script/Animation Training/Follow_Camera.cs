using UnityEngine;

public class Follow_Camera : MonoBehaviour
{
    [SerializeField] Transform target; // 따라다닐 타켓 오브젝트의 Transform

    Transform this_Camera;

    float Damping = 15.0f;
    float distance = 5.0f; // 카메라와 일정 거리
    float height = 5.0f; // 카메라의 높이
    float smooth_Rotate = 5.0f; // 부드러운 회전을 위한 변수
    float Offset = 2.5f;

    void Start()
    {
        this_Camera = GetComponent<Transform>();
    }

    // 캐릭터의 동작이 끝난 뒤에 캐릭터를 추적해야하기 때문에 LateUpdate에서 동작을 처리해야합니다.
    private void LateUpdate()
    {
        // target에서 뒤로 distance만큼 이동하고 위로 height만큼 이동시켜줍니다.     
        var camera_pos = target.position - (target.forward * distance) + (transform.up * height);

        // 보간함수 Slerp를 이용해서 현재위치에서 camera_pos로 시간에 따라 Damping의 회전속도로 이동하게 합니다.
        this_Camera.position = Vector3.Slerp(this_Camera.position, camera_pos, Damping * Time.deltaTime);

        // 카메라의 rotation을 보간함수 Slerp에 따라서 카메라의 회전좌표에서 타켓의 회전좌표로 시간에 따라 회전의 속도로 회전하게 합니다.
        this_Camera.rotation = Quaternion.Slerp(transform.rotation, target.rotation, smooth_Rotate * Time.deltaTime);

        // LockAt()함수를 이용하여 카메라의 z축이 캐릭터의 머리를 바라보게 합니다.
        this_Camera.LookAt(target.position + (target.up * Offset));
    }
}
