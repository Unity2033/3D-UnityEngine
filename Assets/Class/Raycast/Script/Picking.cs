using UnityEngine;

public class Picking : MonoBehaviour
{
    public LayerMask layer;

    void Update()
    {
        // GetMouseButton(0) : 마우스 왼쪽 버튼 클릭을 했을 때     
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // 광선을 발사한 다음 광선과 충돌한 게임 오브젝트가 있다면 hit 변수에 데이터를 저장합니다. 
            // layer는 해당 layer만 검출하여 충돌을 처리합니다.
            if (Physics.Raycast(ray, out hit, layer))
            {
                  hit.collider.gameObject.GetComponent<Renderer>().material = Resources.Load<Material>("Ice");                        
            }
        }
        
    }
}



