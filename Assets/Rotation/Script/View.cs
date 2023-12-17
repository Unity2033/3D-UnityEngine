using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class View : MonoBehaviour
{
    public float time = 2.5f;
    public Texture2D cursorImage;
    public GameObject observeObject;

    public IEnumerator LookCoroutine()
    {
        Cursor.SetCursor(cursorImage, Vector2.zero, CursorMode.Auto);

        yield return new WaitForSeconds(time);

        Camera.main.transform.LookAt(observeObject.transform);
    }

    private void OnBecameVisible()
    {
        StartCoroutine(LookCoroutine());
    }
}
