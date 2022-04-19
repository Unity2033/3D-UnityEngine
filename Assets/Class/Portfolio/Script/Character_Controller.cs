using UnityEngine;

public class Character_Controller : MonoBehaviour
{
    public float speed = 5.0f;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical"); 

        Vector3 dir = new Vector3(x, 0, z);

        transform.Translate(dir.normalized * speed * Time.deltaTime );

        transform.Rotate(0f, Input.GetAxis("Mouse X") * speed, 0f, Space.World);
    }
}
