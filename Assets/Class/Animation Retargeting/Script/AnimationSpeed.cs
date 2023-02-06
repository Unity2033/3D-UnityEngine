using UnityEngine;
using UnityEngine.UI;

public class AnimationSpeed : MonoBehaviour
{
    [SerializeField] DataSystem data;
    [SerializeField] Animator [] animator;

    private void Start()
    {
        for (int i = 0; i < animator.Length; i++)
        {
            animator[i].speed = data.Speed / 10;
        }
    }

    public void SpeedSetting()
    {
        if(data.Speed++ >= 10)
        {
            data.Speed = 1;
        }

        data.Save();
 
        for(int i = 0; i < animator.Length; i++)
        {
            animator[i].speed = data.Speed / 10;
        }
    } 
}
