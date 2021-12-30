using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse_Select : MonoBehaviour
{
    public string [] plante_name;

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray,out hit))
        {
            for (int i = 0; i < plante_name.Length; i++)
            {
                if (hit.transform.gameObject.tag == plante_name[i] && Input.GetMouseButtonDown(0))
                {
                   
                }
            }
        }

    }
}
