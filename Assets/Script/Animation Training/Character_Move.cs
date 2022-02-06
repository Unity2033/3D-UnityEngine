using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Move : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] float speed = 1.0f; // 이동속도

    float gravity = 9.81f; // 중력 계수
    Vector3 Direction; // 이동 방향

    CharacterController character;

    void Start()
    {
        character = GetComponent<CharacterController>();
    }

    void Update()
    {
        // 바닥에 닿았으면 true가 반환되며, 바닥에 닿지 않으면 false값이 반환됩니다.
        if (character.isGrounded == false) 
        {
            // y축에 중력의 계수가 적용되도록 설정합니다.
            Direction.y -= gravity * Time.deltaTime;
        }
        else
        {
            float vertical = Input.GetAxis("Vertical"); // 수직의 정보를 나타냅니다.
                                                        // 키보드 입력에 따라 -1 ~ 1 까지의 정보가 저장됩니다.     

            float horizontal = Input.GetAxis("Horizontal");

            // 애니메이션의 SetFloat()함수는 단발성 호출에 사용되기 때문에 Get 함수가 없습니다.
            animator.SetFloat("vertical", vertical);
            animator.SetFloat("horizontal", horizontal);

            Move_To(new Vector3(horizontal, 0, vertical));
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.Play("Jump", -1, 0);
            Direction = new Vector3(0, 5f, 0);
        }

        character.Move(Direction * speed * Time.deltaTime);
    }

    public void Move_To(Vector3 direction)
    {
        Direction = new Vector3(direction.x, Direction.y, direction.z);
    }
}
