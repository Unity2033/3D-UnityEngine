using System.Collections;
using UnityEngine;

public class Create_Asteroid : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            GameObject Asteroid = Resources.Load<GameObject>("Asteroid");

            Asteroid.transform.rotation = Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
            Asteroid.transform.position = Asteroid.transform.right * 100;

            Instantiate(Asteroid);

            yield return new WaitForSeconds(5.0f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "")
        {

        }
    }
}
