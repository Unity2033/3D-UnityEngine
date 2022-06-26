using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlendAnimation : MonoBehaviour
{
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        animator.SetFloat("Vertical", vertical);
        animator.SetFloat("Horizontal", horizontal);    
    }
}
