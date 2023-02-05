using UnityEngine;
using System.Collections;

public class Revolution : MonoBehaviour
{
    public GameObject moon;
    public GameObject origin; 
    public float speed = 1.0f; 

    private void Start()
    {
        StartCoroutine(RotateCoroutine());
    }

    IEnumerator RotateCoroutine()
    {
        while(true)
        {
            transform.RotateAround
            (
                origin.transform.position,
                Vector3.down,
                speed * Time.deltaTime
            );

            moon.transform.Rotate(0.1f, 0.1f, 0.1f);

            yield return null;
        }
    }

}


