using UnityEngine;

public class Parabola : MonoBehaviour
{
    public GameObject target;
    public float speed = 1.0f;

    void Update()
    {
        // 게임 오브젝트의 위치를 target 오브젝트의 위치로 포물선의 형태로 이동시키는 함수입니다.
        transform.position = Vector3.Slerp(transform.position, target.transform.position, speed * Time.deltaTime);
    }

    public void LeftMove()
    {
        target.transform.position = new Vector3(-4, 2, 3);
    }

    public void RightMove()
    {
        target.transform.position = new Vector3(4, 2, 3);
    }
    


}
