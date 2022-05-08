using System.Collections;
using UnityEngine;

public class Control : MonoBehaviour
{
    bool delay;
    Renderer render;

    private void Start()
    {
        render = gameObject.GetComponent<Renderer>();
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal") * Time.deltaTime; 
        float z = Input.GetAxis("Vertical") * Time.deltaTime;

        transform.Translate(x, 0, z);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(!delay) // 만약에 delay가 false이면 색상을 0,0,0으로 설정시키도록 변경합니다.
            {
                delay = true;
                render.material.color = new Color(0, 0, 0);

                // 코루틴 함수는 StartCoroutine 함수를 통해 호출할 수 있습니다.
                StartCoroutine(AttackDelay());
            }
            else // 그게 아니라면 색상을 0,255,0으로 설정시키도록 변경합니다.
            {
                render.material.color = new Color(0, 255, 0);
            }
        }
    }

    // 코루틴 함수는 IEnumerator 함수를 사용해야 합니다.
    IEnumerator AttackDelay()
    {
        // 2초 후에 다음 동작을 수행하도록 설정합니다.
        yield return new WaitForSeconds(2f);
        delay = false;
        render.material.color = new Color(0, 255, 0);
    }
}
