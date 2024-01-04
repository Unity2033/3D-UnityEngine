using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateManager : MonoBehaviour
{
    public static int count;
    public GameObject monster;
    public Vector3 [ ] vector3;

    public Unit CreateUnit()
    {
        Unit unit = Instantiate(monster).AddComponent<Unit>();

        unit.transform.position = vector3[count++ % vector3.Length];

        return unit;
    }

    public IEnumerator Start()
    {
        while (true)
        {
            Unit unit = CreateUnit();

            yield return new WaitForSeconds(2.5f);

            Destroy(unit.gameObject);
        }
    }
}
