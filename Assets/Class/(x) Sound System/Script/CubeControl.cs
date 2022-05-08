using UnityEngine;

public class CubeControl : MonoBehaviour
{
    Rigidbody rigidbody;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // rigidbody를 이용한 움직임은 고정적인 프레임에서 연산이 이루어져야 합니다. 
    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 dir = new Vector3(x, 0, z);

        // velocity :리지드바디를 사용하여 물체가 특정 속도로 이동할 수 있도록 오브젝트의 무게와 상관없이 일정 속도를 줍니다.
        rigidbody.velocity = dir;
    }


    // Oncollision : 두 오브젝트가 물리 법칙에 영향을 받을 때 사용하는 함수입니다.
    // 두 오브젝트가 부딪혔을 때 충돌을 감지하며, 적어도 하나의 오브젝트의 Rigidbody의 Body Type이 Dynamic으로 설정되어야 합니다.

    private void OnCollisionEnter(Collision collision) // 두 오브젝트가 충돌하는 순간 한번 호출되는 함수입니다.
    {
        // 게임 오브젝트의 이름이 Origin Cube이면 조건문을 실행합니다.
        if(collision.gameObject.name == "Other Cube")
        {
            print("물리적인 충돌을 하였습니다.");
        }
    }

    private void OnCollisionStay(Collision collision) // 두 오브젝트가 충돌하는 동안 계속 호출되는 함수입니다.
    {
        print("물리적인 충돌 중 입니다.");
    }

    private void OnCollisionExit(Collision collision) // 두 오브젝트가 충돌이 끝날 때 호출되는 함수입니다.
    {
        print("물리적인 충돌이 끝났습니다.");
    }


    // OnTrigger : 두 오브젝트가 물리 연산을 하지 않고 충돌을 하려고 할 때 사용하는 함수입니다.
    // 두 오브젝트 중 하나는 Collider의 Is Trigger가 true 상태여야 합니다.
    // Trigger를 사용하는 두 오브젝트는 부딪혔을 때 물리 법칙의 영향을 받지 않고 통과하게 됩니다.

    private void OnTriggerEnter(Collider other)
    {
        print("물리 연산을 하지 않는 충돌을 하였습니다.");
    }

    private void OnTriggerStay(Collider other)
    {
        print("물리 연산을 하지 않고 충돌 중입니다.");
    }

    private void OnTriggerExit(Collider other)
    {
        print("물리 연산을 하지 않는 충돌을 하고 있다가 끝났습니다.");
    }
}
