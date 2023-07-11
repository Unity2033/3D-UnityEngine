using UnityEngine;

public class Mouse : MonoBehaviour
{
    [SerializeField] GameObject state;
    [SerializeField] Texture2D cursorImage;

    private void SetMouse(string name)
    {
        cursorImage = Resources.Load<Texture2D>(name);
        Cursor.SetCursor(cursorImage, Vector2.zero, CursorMode.ForceSoftware);
    }

    private void OnMouseDrag()
    {
        SetMouse("Basic Select Icon");

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
        SetMouse("Basic Icon");
    }

    private void OnMouseExit()
    {
        state.SetActive(false);
    }

    private void OnMouseEnter()
    {
        state.SetActive(true);
    }
}



