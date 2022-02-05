using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_Manager : MonoBehaviour
{
    public Animator animator;
    Character_Move character_move;

    private void Start()
    {
        character_move = GetComponent<Character_Move>();
    }

    void Update()
    {
        float vertical = Input.GetAxis("Vertical"); // 수직의 정보를 나타냅니다.
                                                    // 키보드 입력에 따라 -1 ~ 1 까지의 정보가 저장됩니다.     

        float horizontal = Input.GetAxis("Horizontal");

        // 애니메이션의 SetFloat()함수는 단발성 호출에 사용되기 때문에 Get 함수가 없습니다.
        animator.SetFloat("vertical", vertical);
        animator.SetFloat("horizontal", horizontal);

        character_move.Move_To(new Vector3(horizontal, 0, vertical));

        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.Play("Jump", -1, 0);
        }
    }
}
