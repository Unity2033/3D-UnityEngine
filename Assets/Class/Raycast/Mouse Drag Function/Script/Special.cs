using UnityEngine;

public class Special : MonoBehaviour
{
    Rigidbody rigid;
    ParticleSystem effect;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        effect = GetComponentInChildren<ParticleSystem>();
    }

    private void OnMouseDown()
    {
        effect.Play();
    }

    private void OnMouseDrag()
    {
        rigid.isKinematic = true;

        // 마우스의 위치를 설정합니다.
        Vector3 mouseposition = new Vector3
            (
                  Input.mousePosition.x, 
                  Input.mousePosition.y, 
                  Camera.main.WorldToScreenPoint(gameObject.transform.position).z
            );

        //마우스 좌표를 ScreenToWorldPoint로 변경하여 오브젝트의 위치로 변경합니다.
        Vector3 objposition = Camera.main.ScreenToWorldPoint(mouseposition);

        transform.position = objposition;
    }

    private void OnMouseUp()
    {
        rigid.isKinematic = false;
    }
}



