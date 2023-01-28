using UnityEngine;

public class Picking : MonoBehaviour
{
    public LayerMask layer;
    private RaycastHit hit;
    private Ray ray;

    void Update()
    {  
        if (Input.GetButtonDown("Fire1"))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RandomMesh();        
        }    
    }

    public void RandomMesh()
    { 
        // 광선을 발사한 다음 광선과 충돌한 게임 오브젝트가 있다면 hit 변수에 데이터를 저장합니다.  
        if (Physics.Raycast(ray, out hit, layer)) // layer는 해당 layer만 검출하여 충돌을 처리합니다.
        {
            hit.transform.GetChild(0).GetComponent<SkinnedMeshRenderer>().material = Resources.Load<Material>("Bat Material");
      
        }
    }
}



