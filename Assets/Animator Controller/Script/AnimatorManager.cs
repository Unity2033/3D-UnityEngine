using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AnimatorController
{
    public class AnimatorManager : MonoBehaviour
    {
        public Animator animator;

        public void StartAnimation(string name)
        {
            animator.CrossFade(name, 1.0f);
        }
    }
}
