using UnityEngine;

public class Look : MonoBehaviour
{

    void Update()
    {           
        float x = Input.GetAxis("Mouse X");

        float keyx = Input.GetAxis("Horizontal") * Time.deltaTime;
        float keyz = Input.GetAxis("Vertical") * Time.deltaTime;

        transform.Translate(keyx, 0, keyz);
        transform.Rotate(0, x, 0);

    }
}
