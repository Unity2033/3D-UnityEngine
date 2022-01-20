using UnityEngine;

public class Create_Billiard_Ball : MonoBehaviour
{
    public GameObject[] Billiard_Ball; 

    void Start()
    {
        for(int i = 0; i < Billiard_Ball.Length; i++)
        {
            Instantiate(Billiard_Ball[i], new Vector3(1 * i, 0, 0), Quaternion.identity);
        }       
    }
}
