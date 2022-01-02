using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Other_Ball : MonoBehaviour
{
    MeshRenderer mesh;
    Material material;

    string[] Hole_Name = 
        { 
            "First Hole" , "Second Hole", "Three Hole",
            "Four Hole", "Five Hole","Six Hole"
        };

    public GameObject[] Hole;

    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        material = mesh.material;
    }

    // Oncollision : 두 오브젝트가 물리 법칙에 영향을 받을 때 사용하는 함수입니다.
    // 두 오브젝트가 부딪혔을 때 충돌을 감지하며, 적어도 하나의 오브젝트의 Rigidbody의 Body Type이 Dynamic으로 설정되어야 합니다.
    
    private void OnCollisionEnter(Collision collision) // 두 오브젝트가 충돌하는 순간 한번 호출되는 함수입니다.
    {
        if(collision.gameObject.name == "First Ball")
        {
            // color : 기본 클래스 색상
            material.color = new Color(0, 0, 0);
        }
    }

    private void OnCollisionStay(Collision collision) // 두 오브젝트가 충돌하는 동안 계속 호출되는 함수입니다.
    {

    }

    private void OnCollisionExit(Collision collision) // 두 오브젝트가 충돌이 끝날 때 호출되는 함수입니다.
    {
        if (collision.gameObject.name == "First Ball")
        {
            // color : 기본 클래스 색상
            material.color = new Color(1, 1, 1);
        }
    }


    // OnTrigger : 두 오브젝트가 물리 연산을 하지 않고 충돌을 하려고 할 때 사용하는 함수입니다.
    // 두 오브젝트 중 하나는 Collider의 Is Trigger가 true 상태여야 합니다.
    // Trigger를 사용하는 두 오브젝트는 부딪혔을 때 물리 법칙의 영향을 받지 않고 통과하게 됩니다.
   
    private void OnTriggerStay(Collider other)
    {
        for(int i = 0; i < Hole_Name.Length; i++)
        {
            if (other.gameObject.name == Hole_Name[i])
            {
                Destroy(gameObject, 3);
            }
        }
    }
}
