using System.Threading;
using UnityEngine;

public class Create : MonoBehaviour
{
    public bool createFlag;
    public GameObject prefab;
    private Thread subThread;

    void Start()
    {
        subThread = new Thread(CreateRoutine);

        subThread.Start();
    }

    private void Update()
    {
        if (createFlag == true)
        {
            Instantiate
            (
                prefab, Vector3.down, prefab.transform.rotation
            ).AddComponent<Delete>();

            createFlag = false;
        }
    }

    private void CreateRoutine()
    {
        while (true)
        {
            Thread.Sleep(5000);

            createFlag = true;
        }
    }
}






