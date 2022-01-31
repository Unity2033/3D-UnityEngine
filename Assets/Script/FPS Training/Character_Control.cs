using UnityEngine;

public class Character_Control : MonoBehaviour
{
    [Tooltip("Character Speed")] 
    public float Character_speed = 5.0f;

    [Tooltip("Rotate Speed")]
    public float Rotate_speed = 4.0f;

    [Tooltip("Bullet Speed")]
    public float Bullet_speed = 25.0f;

    public GameObject Gun;

    float X_Rotate = 0.0f; // 내부에 사용할 X축 회전량은 별도로 정의합니다. 

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    void Character_Move()
    {
        Vector3 dir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        transform.Translate(dir * Character_speed * Time.deltaTime);
    }

    void Character_Rotation()
    {
        // 좌우로 움직인 마우스의 이동량 * 속도에 따라 카메라가 좌우로 회전할 데이터를 계산합니다.
        float Y_Rotate_Size = Input.GetAxis("Mouse X") * Rotate_speed;

        // 현재 Y축 회전값에 더한 새로운 회전각도를 계산합니다.
        float Y_Rotate = transform.eulerAngles.y + Y_Rotate_Size;

        // 위 아래로 움직인 마우스의 이동량 * 속도에 따라 카메라가 회전할 데이터를 계산합니다. 
        float X_Rotate_Size = -Input.GetAxis("Mouse Y") * Rotate_speed;

        // 위 아래 회전량을 더해주지만 -45도 ~ 80도로 제한 (-45 : 위쪽 방향, 80 : 아래 방향)
        // Clamp : 값의 범위를 제한하는 함수입니다.
        X_Rotate = Mathf.Clamp(X_Rotate + X_Rotate_Size, -45, 80);

        // 카메라 회전량을 카메라에 반형합니다. (X, Y 축만 회전합니다.)
        transform.eulerAngles = new Vector3(X_Rotate, Y_Rotate, 0);
    }

    void Update()
    {
        Character_Move();
        Character_Rotation();


        if (Input.GetMouseButtonDown(0))
        {
            GameObject t_object = Queue_Object_Pool.instance.Get_Queue();

            t_object.transform.position = Gun.transform.position;
            t_object.transform.rotation = Gun.transform.rotation;

            t_object.GetComponent<Rigidbody>().velocity = Vector3.zero;
            t_object.GetComponent<Rigidbody>().AddForce(transform.forward * Bullet_speed);
        }

         // transform.Translate : 프레임마다 일정 속도를 가지고 일정거리만큼 계속 이동하는 함수입니다. 
         // transform.Translate의 인수로는 이동할 방향과 속력을 의미합니다.

         // 스크립트에서 회전은 쿼터니온 형식을 사용하며 벡터와는 다른 사원수 체계를 이용해 오브젝트를 회전시킵니다.
         // 3차원 벡터를 이용해서 회전을 다루는 방법은 오일러 각 체계로 회전시킵니다.
         // transform.rotation = Quaternion.Euler(0f, (Mathf.Cos(1) * 0.5f + 0.5f) * 360f, 0f);
    }
}
