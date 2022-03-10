using UnityEngine;

public class Picking : MonoBehaviour
{
    void Update()
    {
        // GetMouseButton(0) : 마우스 오른쪽 클릭을 했을 때 
        
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // 광선을 발사한 다음 게임 오브젝트가 있다면 hit 변수에 데이터를 저장합니다. 
            if (Physics.Raycast(ray, out hit))
            {
                Debug.DrawLine(ray.origin, hit.point, Color.red, 2, false);
            }
        }
    }
}
