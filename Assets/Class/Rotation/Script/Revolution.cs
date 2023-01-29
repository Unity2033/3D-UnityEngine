using UnityEngine;
using System.Collections;

public class Revolution : MonoBehaviour
{
    public GameObject moon;
    public GameObject origin; // 기준 축이 되는 게임 오브젝트
    public float speed = 1.0f; // 회전 속도

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


