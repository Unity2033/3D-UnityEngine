using UnityEngine;

public class Keystroke : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            Debug.Log("Space Key");
        }

        if(Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("A Key Input");
        }

        if(Input.GetKeyUp(KeyCode.A))
        {
            Debug.Log("A Key Output");
        }
    }
}
