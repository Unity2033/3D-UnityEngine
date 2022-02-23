using UnityEngine;

public class Parabola : MonoBehaviour
{
    // 최종적으로 이동할 기준점이 되는 게임 오브젝트
    public GameObject target;

    // 이동하는 속도 변수
    float speed = 1.0f;

    int value = 0;

    private void Start()
    {
        InvokeRepeating("Increase", 0, 2);
    }

    void Update()
    {
        transform.position = Vector3.Slerp(transform.position, target.transform.position, speed * Time.deltaTime);

        if(value % 2 == 0)
        {
            target.transform.position = new Vector3(4, 2, 3);
        }
        else
        {
            target.transform.position = new Vector3(-4, 2, 3);
        }

    }

    void Increase()
    {
        value++;
    }
}
