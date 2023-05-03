using UnityEngine;

public class BilliardBall : MonoBehaviour
{
    private Vector3 direction;
    [SerializeField] float speed = 5.0f;
    [SerializeField] Rigidbody rigidBody;

    private void Update()
    {
        direction.x = Input.GetAxis("Horizontal");
        direction.z = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        rigidBody.AddForce
        (
            direction * speed, ForceMode.Acceleration
        );
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Pillar"))
        {
            var result = Vector3.Reflect
            (
                 transform.position.normalized, 
                 collision.contacts[0].normal
            );

            rigidBody.velocity = result * Mathf.Max(speed, 0f);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Billiard Ball"))
        {
            rigidBody.AddTorque
            (
               Vector3.up * speed,
               ForceMode.Impulse
            );
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Pillar"))
        {
            int randomMode = Random.Range(0, 3);
            rigidBody.interpolation = (RigidbodyInterpolation)randomMode;
        }
    }
}
