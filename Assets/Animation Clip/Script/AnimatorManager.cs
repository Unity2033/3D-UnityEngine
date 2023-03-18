using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimatorManager : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] float speed = 1.0f;


    void Update()
    {
        // 애니메이터 컨트롤러에서 현재 애니메이터의 상태의 이름이“close”일 때 
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Close"))
        {
            // 현재 애니메이션의 진행도가 1보다 크거나 같다면 User Interface를 비활성화합니다.
            if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
            {
                animator.gameObject.SetActive(false);
            }
        }
    }

    public void Close()
    {
        animator.SetTrigger("Close");
    }

    public void Open()
    {
        animator.gameObject.SetActive(true);
    }
}
