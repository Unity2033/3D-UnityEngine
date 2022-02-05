using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Move : MonoBehaviour
{
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

        character.Move(Direction * speed * Time.deltaTime);
    }

    public void Move_To(Vector3 direction)
    {
        Direction = new Vector3(direction.x, Direction.y, direction.z);
    }
}
