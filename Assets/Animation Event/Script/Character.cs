using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Character : MonoBehaviour
{
    public TitanRobot titanRobot;

    public void Damage(float damage)
    {
        titanRobot.State(damage);
    }

    public void Animation(string name)
    {
        titanRobot.GetComponent<Animator>().Play(name);
    }
}

