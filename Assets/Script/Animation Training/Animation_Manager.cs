using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_Manager : MonoBehaviour
{
    public Animator animator;

    float horizontal;
    float vertical;

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal"); // 수평의 정보를 나타냅니다.  
        vertical = Input.GetAxis("Vertical");     // 수직의 정보를 나타냅니다.

        // 키보드 입력에 따라 -1 ~ 1 까지의 정보가 저장됩니다.

        animator.SetFloat("horizontal", horizontal);
        animator.SetFloat("vertical", vertical);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.Play("Jump", -1, 0); 
        }
    }
}
