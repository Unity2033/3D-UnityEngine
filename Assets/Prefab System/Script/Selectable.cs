using UnityEngine;


[RequireComponent(typeof(BoxCollider))] 
public class Selectable : MonoBehaviour
{
    [SerializeField] Texture2D mouse;

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

    private void OnMouseEnter()
    {       
        mouse = Resources.Load<Texture2D>("Enter Cursor");
        Cursor.SetCursor(mouse, Vector2.zero, CursorMode.Auto);
    }

    private void OnMouseExit()
    {
        mouse = Resources.Load<Texture2D>("Basic Cursor");
        Cursor.SetCursor(mouse, Vector2.zero, CursorMode.Auto);
    }
}



