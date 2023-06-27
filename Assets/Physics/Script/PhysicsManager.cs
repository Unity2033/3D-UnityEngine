
using UnityEngine;

public class PhysicsManager : MonoBehaviour
{
    private Ray ray;
    private RaycastHit rayCastHit;
    [SerializeField] LayerMask [ ] layerMask = new LayerMask[3];

    private void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetButtonDown("Fire1"))
        {
            for (int i = 0; i < layerMask.Length; i++)
            {              
                if (Physics.Raycast(ray, out rayCastHit, Mathf.Infinity, layerMask[i]))
                {
                    rayCastHit.collider.GetComponent<Rigidbody>().Sleep();
                }
            }
        }
    }
}
