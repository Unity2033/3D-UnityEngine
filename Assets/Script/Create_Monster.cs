using UnityEngine;

public class Create_Monster : MonoBehaviour
{
    public GameObject Monster;

    void Start()
    {
        Instantiate(Monster, new Vector3(Random.Range(-50, 50), 0, 50), Quaternion.identity);
    }
}
