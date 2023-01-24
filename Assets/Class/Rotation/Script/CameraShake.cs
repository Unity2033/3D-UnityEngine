using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private float endTime = 0;
    private Vector3 direction;

    void Start()
    {
        direction = transform.localPosition;
    }

    public void CameraEffect()
    {
        StartCoroutine(Shake(0.5f, 0.25f));
    }

    public IEnumerator Shake(float amount, float duration)
    {
        while (endTime <= duration)
        {
            transform.localPosition = (Vector3)Random.insideUnitCircle * amount + direction;

            duration -= Time.deltaTime;

            yield return null;
        }

        transform.localPosition = direction;
    }
}
