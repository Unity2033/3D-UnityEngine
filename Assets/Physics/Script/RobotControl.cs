using UnityEngine;

public class RobotControl : MonoBehaviour
{
    public int speed = 2;
    public float radius = 1.5f;

    private Vector3 direction;
    private Rigidbody rigidBody;
    private Collider [ ] colliders;

    private void Start()
    {
        Cursor.visible = false;                   
        Cursor.lockState = CursorLockMode.Locked;   

        rigidBody = GetComponent<Rigidbody>();
    }

    public void Update()
    {
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.z = Input.GetAxisRaw("Vertical");
    }

    public void Detection()
    {
        colliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider element in colliders)
        {
            if (element.CompareTag("Billiard Ball"))
            {
                element.GetComponent<PhysicsControl>().AddForceMessage(rigidBody.transform.forward);
            }
        }
    }

    private void FixedUpdate()
    {
        Detection();

        rigidBody.rotation = rigidBody.rotation * Quaternion.Euler(0, Input.GetAxis("Mouse X"), 0);

        rigidBody.transform.position += rigidBody.transform.TransformDirection
        (
            direction.normalized * speed *  Time.fixedDeltaTime
        );
    }

}
