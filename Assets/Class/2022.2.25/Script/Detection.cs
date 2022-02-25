using UnityEngine;

public class Detection : MonoBehaviour
{
    public float range = 1.0f;

    void FixedUpdate()
    {
        Collider[] collider = Physics.OverlapSphere(transform.position, range);

        if(collider.Length > 0)
        {
           
        }
    }
}
