using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Networking;

public class Network_Timer : MonoBehaviour
{
    public string url = "";

    void Start()
    {
        StartCoroutine(Web());
    }

    IEnumerator Web()
    {
        UnityWebRequest request = new UnityWebRequest();

        using (request = UnityWebRequest.Get(url))
        {
            yield return request.SendWebRequest();
       
            if(request.isNetworkError)
            {
                Debug.Log(request.error);
            }
            else
            {
               string date = request.GetResponseHeader("date");

                DateTime dataTime = DateTime.Parse(date);
                Debug.Log(dataTime);
            }
        
        }
    
    }
}
