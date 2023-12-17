using UnityEngine;


[RequireComponent(typeof(BoxCollider))] 
public class Selectable : MonoBehaviour
{
    [SerializeField] Texture2D cursorImage;

    private void SetMouse(string name)
    {
        cursorImage = Resources.Load<Texture2D>(name);
        Cursor.SetCursor(cursorImage, Vector2.zero, CursorMode.ForceSoftware);
    }

    private void OnMouseDrag()
    {
        Vector3 mousePosition = new Vector3
        (
             Input.mousePosition.x, 
             Input.mousePosition.y, 
             Camera.main.WorldToScreenPoint(gameObject.transform.position).z
        );

        transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
    }

    private void Awake()
    {
        SetMouse("Basic Icon");
    }

    private void OnMouseEnter()
    {       
        SetMouse("Select Icon");
    }

    private void OnMouseExit()
    {
        SetMouse("Basic Icon");
    }
}



