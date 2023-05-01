using UnityEngine;
using UnityEngine.UI;

namespace AnimationRetargeting
{
    public class AnimatorManager : MonoBehaviour
    {
        private float speed = 10;

        [SerializeField] Animator[] animator;

        public void SpeedSetting()
        {    
            speed += speed + 1;

            for (int i = 0; i < animator.Length; i++)
            {
                animator[i].speed = speed % 10 / 10;
            }
        }
    }
}
