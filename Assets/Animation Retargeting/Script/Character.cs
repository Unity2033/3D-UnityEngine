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
        int rand = Random.Range(0, 2);

        if (rand == 0)
        {
            gameObject.GetComponent<Animator>().Play(name);
        }  
    }

}

