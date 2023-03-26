using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationAction : MonoBehaviour
{
    public Animator animator;

    public void AnimationPlay(string name)
    {
        animator.Play(name);
    }
}
