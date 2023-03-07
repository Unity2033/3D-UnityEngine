using UnityEngine;

public class AnimationManager: MonoBehaviour
{
    private bool condition;
    private float speed = 10;
    [SerializeField] Animator [] animator;

    private void Start()
    {
        for (int i = 0; i < animator.Length; i++)
        {
            animator[i].speed = speed / 10;
        }
    }

    public void SpeedSetting()
    {
        if(speed++ >= 10)
        {
            speed = 1;
        }

        for(int i = 0; i < animator.Length; i++)
        {
            animator[i].speed = speed / 10;
        }
    }

    public void LayerMaskSetting(int layerIndex)
    {
        condition = !condition;

        switch (condition)
        {
            case true : Camera.main.cullingMask = 1 << layerIndex;
                break;
            case false : Camera.main.cullingMask = ~(1 << layerIndex);
                break;
        }
    }

    public void Everything()
    {
        Camera.main.cullingMask = -1;
    }
}
