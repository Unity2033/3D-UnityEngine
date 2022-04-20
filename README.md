using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    float speed = 5.0f;
    
    float MouseY = 0f;
    float MouseX = 0f;

    float Jump = 100.0f;
    bool count = false;

    Rigidbody rigid;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(x, 0, z);

        transform.Translate(dir.normalized * speed * Time.deltaTime);

        MouseX += Input.GetAxis("Mouse X") * speed;
        MouseY += Input.GetAxis("Mouse Y") * speed;
        
        MouseY = Mathf.Clamp(MouseY, -55, 55);

        transform.localEulerAngles = new Vector3(-MouseY, MouseX, 0);
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space) && count == false)
        {
            rigid.AddForce(Vector3.up * Jump * Time.deltaTime, ForceMode.Impulse);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.name == "Terrain")
        {
            count = false;
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.name == "Terrain")
        {
            count = true;
        }
    }
}


