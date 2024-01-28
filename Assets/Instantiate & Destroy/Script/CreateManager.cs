using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateManager : MonoBehaviour
{
    public GameObject monster;
    public Vector3 [ ] vector3;

    public IEnumerator Start()
    {
        while (true)
        {
            Unit unit = Instantiate(monster).AddComponent<Unit>();

            unit.transform.position = vector3[Random.Range(0, vector3.Length)];

            yield return new WaitForSeconds(2.5f);

            Destroy(unit.gameObject);
        }
    }
}
