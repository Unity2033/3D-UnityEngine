using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] Skeleton skeleton;

    public void Damage(float attack)
    {
        skeleton.State(attack);
    }

    public void Skill(string name)
    {
        if(Random.Range(0, 2) == 0)
        {
            gameObject.GetComponent<Animator>().CrossFade(name, 0.25f);
        }
   
    }
}

