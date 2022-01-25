using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_Manager : MonoBehaviour
{
    public Animator animator;

    void Update()
    {
        float vertical = Input.GetAxis("Vertical"); // 수직의 정보를 나타냅니다.
                                                    // 키보드 입력에 따라 -1 ~ 1 까지의 정보가 저장됩니다.     

        float horizontal = Input.GetAxis("Horizontal");

        animator.SetFloat("vertical", vertical);
        animator.SetFloat("horizontal", horizontal);

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    animator.Play("Jump", -1, 0);
        //}

        //if (Input.GetKeyDown(KeyCode.Z))
        //{
        //    // 애니메이션의 SetFloat()함수는 단발성 호출에 사용되기 때문에 Get 함수가 없습니다.
        //    animator.SetFloat("vertical", 5.0f);
        //}

        //if (Input.GetKeyDown(KeyCode.X))
        //{
        //    animator.SetFloat("vertical", 0.0f);
        //}
    }
}
