using System.Collections;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    Rigidbody rigid;
    Transform Target;
    public string [] Planet;

    Vector3 rotation;

    public float speed = 1.0f;

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
        Target = GameObject.Find("Sun").GetComponent<Transform>();
    }

    void Update()
    {
        rotation = new Vector3(100,100,100) * Time.deltaTime;
        rigid.MoveRotation(transform.rotation * Quaternion.Euler(rotation));

        transform.position = Vector3.MoveTowards(transform.position, Target.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < Planet.Length; i++)
        {
            if (other.gameObject.tag == Planet[i])
            {            
                Queue_Object_Pool.instance.Insert_Queue(gameObject);
            }
        }
    }
}
