using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            // 실행할 게임 스테이트의 이름을 설정합니다.
            animator.Play("Run");
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {     
            animator.SetBool("Jump",true);
        }

        if (Input.GetKeyUp(KeyCode.Return))
        {
            animator.SetBool("Jump", false);
        }
    }
}
