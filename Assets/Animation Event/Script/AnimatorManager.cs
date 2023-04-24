using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AnimationEvent
{
    public class AnimatorManager : MonoBehaviour
    {
        public Animator animator;

        public void Running(float value)
        {
            animator.CrossFade("Running", value);
        }
    }
}
