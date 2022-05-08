using UnityEngine;

public class Character_Controller : MonoBehaviour
{
    public float speed = 5.0f;
    float mx;
    float my;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical"); 

        Vector3 dir = new Vector3(x, 0, z);

        transform.Translate(dir.normalized * speed * Time.deltaTime );

        transform.Rotate(0f, Input.GetAxis("Mouse X") * speed, 0f, Space.World);

        //1. 마우스 입력을 받는다.

        float mouse_X = Input.GetAxis("Mouse X");

        float mouse_Y = Input.GetAxis("Mouse Y");


       //1-1. 회전 값 변수에 마우스 입력 값만큼 미리 누적시킨다
        mx += mouse_X * 100 * Time.deltaTime;
        my += mouse_Y * 100 * Time.deltaTime;

        //1-2. 마우스 상하 이동 회전 변수(my)의 값을 -90 ~ 90도 사이로 제한한다.
        my = Mathf.Clamp(my, -60f, 60f);

        //2. 회전 방향으로 물체를 회전시킨다.
        //r = r0+ vt

        transform.eulerAngles = new Vector3(-my, mx, 0);
    }
}
