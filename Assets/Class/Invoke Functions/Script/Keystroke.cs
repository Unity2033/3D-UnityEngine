using UnityEngine;

public class Keystroke : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            // transform.position은 자기 자신의 위치를 나타냅니다.
            // Vector3.left = (-1,0,0)의 방향을 의미합니다.
            transform.position += Vector3.left * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            // Vector3.right = (1,0,0)의 방향을 의미합니다.
            transform.position += Vector3.right * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.W))
        {
            // Vector3.forward = (0,0,1)의 방향을 의미합니다.
            transform.position += Vector3.forward * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            // Vector3.back = (0,0,-1)의 방향을 의미합니다.
            transform.position += Vector3.back * Time.deltaTime; 
        }
    }
}
