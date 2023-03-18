using UnityEngine;
using UnityEngine.UI;

public class State : MonoBehaviour
{
    private Animator animator;
    [SerializeField] Slider healthGauge;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void StateLayer(float health)
    {
        healthGauge.value = health;

        float Temporary = 1 - healthGauge.value;

        animator.SetLayerWeight(animator.GetLayerIndex("Other Layer"), Temporary);
    }

}
