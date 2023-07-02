using UnityEngine;

public class Mouse : MonoBehaviour
{
    [SerializeField] GameObject state;
    [SerializeField] Texture2D cursorImage;


    private void Update()
    {
        Cursor.SetCursor(cursorImage, Vector2.zero, CursorMode.ForceSoftware);
    }


    private void OnMouseDown()
    {
        // state.SetActive(true);
        
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

        state.SetActive(false);
    }

    private void OnMouseUp()
    {
        state.SetActive(true);
    }

    private void OnMouseExit()
    {
        cursorImage = Resources.Load<Texture2D>("Basic Icon");
    }

    private void OnMouseEnter()
    {
        cursorImage = Resources.Load<Texture2D>("Basic Select Icon");
    }
}



