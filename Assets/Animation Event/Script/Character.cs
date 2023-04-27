using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Character : MonoBehaviour
{
    public Animator animator;
    public TitanRobot titanRobot;

    public void Damage(float damage)
    {
        titanRobot.State(damage);
    }

    public void Running(float value)
    {
        animator.CrossFade("Running", value);
    }
}

