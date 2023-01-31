using UnityEngine;
using UnityEngine.Video;

public class Sensor : MonoBehaviour
{
    public Material[] material;
 
    // 물리적인 충돌을 하지 않고 충돌을 했을 때 동작하는 함수입니다.
    private void OnTriggerEnter(Collider other)
    {
        gameObject.GetComponent<MeshRenderer>().material = material[0];
    }

    // 물리적인 충돌을 하지 않고 충돌을 하고 있을 때 동작하는 함수입니다.
    private void OnTriggerStay(Collider other)
    {
   
    }

    // 물리적인 충돌을 하지 않고 충돌을 벗어났을 때 동작하는 함수입니다.
    private void OnTriggerExit(Collider other)
    {
        gameObject.GetComponent<MeshRenderer>().material = material[1];
    }

}
