using UnityEngine;

public class Airplane_Control : MonoBehaviour
{
    float speed = 10.0f;
    public GameObject Headlight;
    public GameObject Bullet;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float Vertical = Input.GetAxis("Vertical");
        float Horizontal = Input.GetAxis("Horizontal");

        transform.Rotate(0, 0, Horizontal * -speed * 2  *Time.deltaTime);      
        transform.Translate(new Vector3(0, 0, Vertical * speed * Time.deltaTime));

        transform.Rotate(-Input.GetAxis("Mouse Y") * Mathf.Pow(speed, 2) * Time.deltaTime, 0f, 0f);
        transform.Rotate(0f, +Input.GetAxis("Mouse X") * Mathf.Pow(speed,2) * Time.deltaTime, 0f, Space.World);

        if (Input.GetMouseButtonDown(0))
        {
            GameObject t_object = Queue_Object_Pool.instance.Get_Queue();
            t_object.transform.position = Headlight.transform.position;
            t_object.GetComponent<Rigidbody>().AddForce(transform.forward * 100);     
        }

        if (Input.GetMouseButtonDown(1))
        {
            Headlight.SetActive(true);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Headlight.SetActive(false);
        }

         // transform.Translate : 프레임마다 일정 속도를 가지고 일정거리만큼 계속 이동하는 함수입니다. 
         // transform.Translate의 인수로는 이동할 방향과 속력을 의미합니다.

         // 스크립트에서 회전은 쿼터니온 형식을 사용하며 벡터와는 다른 사원수 체계를 이용해 오브젝트를 회전시킵니다.
         // 3차원 벡터를 이용해서 회전을 다루는 방법은 오일러 각 체계로 회전시킵니다.
         // transform.rotation = Quaternion.Euler(0f, (Mathf.Cos(1) * 0.5f + 0.5f) * 360f, 0f);
    }
}
