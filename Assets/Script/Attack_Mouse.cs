
using UnityEngine;

public class Attack_Mouse : MonoBehaviour
{


    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit Hit;
            Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out Hit,Mathf.Infinity))
            {
                Debug.Log("냥");
            }
        }

    }
}
