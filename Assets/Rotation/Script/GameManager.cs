using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
 
    public IEnumerator Start()
    {

        yield return new WaitUntil(() => Time.time >= 60.0f);


    }


}
