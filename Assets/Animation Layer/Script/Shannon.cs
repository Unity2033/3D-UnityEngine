using UnityEngine;

public class Shannon : MonoBehaviour
{
  
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Update()
    {
       // animator.SetLayerWeight(animator.GetLayerIndex("Other Layer"), Temporary);
    }


}
