using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    public Image healthGauge;
    public Character opponent;
    private float health = 100.0f;

    private void Start()
    {
        healthGauge.fillAmount = health;
    }

    public void State(float value)
    {
        health -= value;
        healthGauge.fillAmount = health / 100;
    }

    public void Damage(float damage)
    {
        State(damage);
    }

    public void Animation(string name)
    {
        opponent.GetComponent<Animator>().Play(name);
    }

    public void Opportunity(int count)
    {
        var rand = Random.Range(0, 2);

        if(count == rand)
        {
            gameObject.GetComponent<Animator>().SetTrigger("Attack");
        }
        else
        {
            opponent.GetComponent<Animator>().SetTrigger("Attack");
        }
    }
}

