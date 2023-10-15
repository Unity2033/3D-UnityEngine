using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UI;

public class Create : MonoBehaviour
{
    public GameObject prefab;

    private CancellationTokenSource tokenSource = new CancellationTokenSource();

    void Start()
    {
        CreateObject();
    }

    private async void CreateObject()
    {
        while (true)
        {
            try
            {
                await Task.Delay(5000, tokenSource.Token);
            }
            catch
            {
                break;
            }
            
            Instantiate
            (
                prefab,
                new Vector3(0, -1.25f, 0),
                prefab.transform.rotation
            ).AddComponent<Delete>();
        }
    }

    private void OnDestroy()
    {
          tokenSource.Cancel();
    }
}






