using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse_Select : MonoBehaviour
{
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray,out hit))
        {
            if(hit.transform.gameObject.tag == "Sun" && Input.GetMouseButtonDown(0))
            {
                Debug.Log("Sun");
            }
        }

    }
}
