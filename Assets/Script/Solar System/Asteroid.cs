using System.Collections;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    Rigidbody rigid;
    Transform Target;
    public string [] Planet;

    Vector3 dir, rotation;

    public float speed = 1.0f;

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
        Target = GameObject.Find("Sun").GetComponent<Transform>();

        dir = Target.transform.position - transform.position;
    }

    void Update()
    {
        rotation = new Vector3(100,100,100) * Time.deltaTime;

        rigid.MovePosition(transform.position + dir * speed * Time.deltaTime);
        rigid.MoveRotation(transform.rotation * Quaternion.Euler(rotation));
    }

    private void OnTriggerEnter(Collider other)
    {
        for(int i = 0; i < Planet.Length; i++)
        {
            if (other.gameObject.tag == Planet[i])
            {
                Destroy(gameObject);
            }
        }
    }
}
