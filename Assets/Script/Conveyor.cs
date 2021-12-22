using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour
{
    public GameObject Belt;
    public Transform Point;

    public float max_speed;
    public float current_speed;

    GameObject main_Camera;

    public GameObject power_Switch;
    public GameObject speed_Switch;
    public GameObject button_Hit;

    bool belt_switch;

    private void Start()
    {
        main_Camera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    private void OnTriggerStay(Collider other)
    {
        other.transform.position = Vector3.MoveTowards
           (
            other.transform.position,
            Point.position,
            current_speed * Time.deltaTime
           );
    }
}
