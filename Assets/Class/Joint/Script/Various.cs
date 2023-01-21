using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Various : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Paint());
    }

    IEnumerator Paint()
    {
        while (true)
        {
            yield return new WaitForSeconds(3.0f);

            gameObject.GetComponent<Renderer>().material.color = 
                new Color
                (
                    Random.Range(0, 2), 
                    Random.Range(0, 2), 
                    Random.Range(0, 2)
                );
        }
    }
}
