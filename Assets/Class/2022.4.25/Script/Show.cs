using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Show : MonoBehaviour
{
    public GameObject Character;
    public GameObject Prefab;

    List<GameObject> object_data = new List<GameObject>();
    List<Transform> position_data = new List<Transform>();

    private Camera maincamera;

    void Start()
    {
        maincamera = Camera.main;

        // 태그가 Other인 오브젝트를 전체적으로 저장합니다.
        GameObject[] t_object = GameObject.FindGameObjectsWithTag("Other");
       

        for(int i = 0; i < t_object.Length; i++)
        {
            // 위치 정보에 태그가 Other인 오브젝트의 위치를 저장합니다.
            position_data.Add(t_object[i].transform);
            GameObject create_object = Instantiate(Prefab, t_object[i].transform.position, Quaternion.identity, transform);
            object_data.Add(create_object);
        }

    }

    void Update()
    {
        for(int i = 0; i < object_data.Count; i++)
        {
            object_data[i].transform.position = maincamera.WorldToScreenPoint(position_data[i].position + new Vector3(0, 1.15f, 0));
        }

        transform.LookAt(Character.transform.position);
    }
}
