using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blend_Control : MonoBehaviour
{
    Animator animator;
    CharacterController control;

    public float speed = 1.0f;

    void Start()
    {
        animator = GetComponent<Animator>();
        control = GetComponent<CharacterController>();
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        animator.SetFloat("Horizontal", h);
        animator.SetFloat("Vertical", v);

        Vector3 dir = new Vector3(h, 0, v);

        control.Move(dir.normalized * speed * Time.deltaTime);
    }
}
