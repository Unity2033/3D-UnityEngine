using UnityEngine;
using UnityEngine.UI;

namespace AnimationRetargeting
{
    public class AnimatorManager : MonoBehaviour
    {
        private int count;
        private float speed = 10;

        [SerializeField] Dropdown dropDown;
        [SerializeField] Animator[] animator;

        public void SpeedSetting()
        {    
            speed += speed + 1;

            for (int i = 0; i < animator.Length; i++)
            {
                animator[i].speed = speed % 10 / 10;
            }
        }

        public void LayerMaskSetting(int layerIndex)
        {
            count = count % 2;

            switch (count++)
            {
                case 0:
                    Camera.main.cullingMask = ~(1 << layerIndex);
                    break;
                case 1:
                    Camera.main.cullingMask = -1;
                    break;
            }
        }

        public void CullingModeSetting()
        {
            int index = dropDown.value;

            for (int i = 0; i < animator.Length; i++)
            {
                animator[i].cullingMode = (AnimatorCullingMode)index;
            }
        }
    }
}
