using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    bool delay;

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal") * Time.deltaTime; 
        float z = Input.GetAxis("Vertical") * Time.deltaTime;

        transform.Translate(x, 0, z);

        int layerMask = 1 << LayerMask.NameToLayer("Monster");

        var ray = new Ray(this.transform.position, this.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100, layerMask))
        {
            Debug.Log("냥");
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(!delay)
            {
                delay = true;
                Debug.Log("공격");
                StartCoroutine(AttackDelay());
            }
            else
            {
                Debug.Log("딜레이");
            }
        }
    }

    IEnumerator AttackDelay()
    {
        yield return new WaitForSeconds(2f);
        delay = false;
    }
}
