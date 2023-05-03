using UnityEngine;
using UnityEngine.Video;

public class Mouse : MonoBehaviour
{
    [SerializeField] Rigidbody rigid;
    [SerializeField] GameObject state;
    [SerializeField] VideoPlayer video; 

    private void OnMouseDown()
    {
        state.SetActive(true);
        rigid.isKinematic = true;
    }

    private void OnMouseDrag()
    {
        // 마우스의 위치를 설정합니다.
        Vector3 mousePosition = new Vector3
        (
             Input.mousePosition.x, 
             Input.mousePosition.y, 
             Camera.main.WorldToScreenPoint(gameObject.transform.position).z
        );

        //마우스 좌표를 ScreenToWorldPoint로 변경하여 오브젝트의 위치로 변경합니다.
        Vector3 objectPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        transform.position = objectPosition;
    }

    private void OnMouseUp()
    {
        state.SetActive(false);
        rigid.isKinematic = false;
    }
}



