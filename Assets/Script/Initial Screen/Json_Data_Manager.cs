using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

// 데이터를 저장하는 방법
// 1. 저장할 데이터가 존재해야 합니다.
// 2. 데이터를 Json으로 변환합니다.
// 3. Json을 외부에 저장합니다.

// 불러오는 방법
// 1. 외부에 저장된 Json을 가져옵니다.
// 2. Json을 데이터형태로 변환합니다.
// 3. 불러올 데이터를 사용합니다.


public class Data // 저장을 하기 위한 데이터
{
    public string name;
    public int age;
    public int money;
}

public class Json_Data_Manager : MonoBehaviour
{
    public static Json_Data_Manager instance;

    string path;
    string filename = "save";

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(instance.gameObject);
        }

        DontDestroyOnLoad(gameObject);

        path = Application.persistentDataPath + "/";
    }

    Data player = new Data() { name = "사람", age = 10, money = 20 };

    public void Save_Data()
    {
        // < Json으로 변환 >
        // Json은 string이기 때문에 string 변수에 넣어주어야 합니다.
        string json_Data = JsonUtility.ToJson(player);

        print(path);
        File.WriteAllText(path + filename, json_Data);
    }

    public void Load_Data()
    {
        string data = File.ReadAllText(path + filename);

        // data가 <Data> 형식으로 변환됩니다.
        // 불러온 데이터 player 덮어 쓰입니다.
        player = JsonUtility.FromJson<Data>(data);
    }


}
