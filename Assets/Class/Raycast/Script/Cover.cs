using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cover : MonoBehaviour
{
    public GameObject[] Equipment;
    public int [] count;

    public void Wearing(int element)
    {
        if (++count[element] % 2 == 0)
        {
            Equipment[element].SetActive(true);
        }
        else
        {
            Equipment[element].SetActive(false);
        }
    }
}
