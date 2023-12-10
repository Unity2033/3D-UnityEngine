using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class View : MonoBehaviour
{
    public float time = 2.5f;
    public GameObject observeObject;

    public IEnumerator LookCoroutine()
    {
        yield return new WaitForSeconds(time);

        Camera.main.transform.LookAt(observeObject.transform);
    }

    private void OnBecameVisible()
    {
        StartCoroutine(LookCoroutine());
    }

}
