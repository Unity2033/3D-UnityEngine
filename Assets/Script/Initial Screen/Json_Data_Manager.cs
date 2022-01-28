using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 1. 데이터(코드 = 클래스)를 만들어야 합니다. -> 저장할 데이터를 생성해야합니다.
// 2. 그 데이터를 Json으로 변환합니다.

class Data
{
    public string name;
    public int age;
    public int money;
}

public class Json_Data_Manager : MonoBehaviour
{
    Data player = new Data() { name = "사람", age = 10, money = 20 };

    void Start()
    {
        // 2. Json으로 변환
        // Json은 string이기 때문에 string 변수에 넣어주어야 합니다.
       string json_Data = JsonUtility.ToJson(player);

       // Json을 다시 코드로 바꾸는 방법
       Data player_ = JsonUtility.FromJson<Data>(json_Data);
    }

    void Update()
    {
        
    }
}
