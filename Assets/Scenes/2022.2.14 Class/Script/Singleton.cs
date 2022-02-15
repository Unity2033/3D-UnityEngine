using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour
{
    private static Singleton instance;

    private void Awake( )
    {
        if (instance == null) // instance가 null이라면 자기 자신을 instance에 넣습니다.
        {
            instance = this;
        }
        else // instance가 있다면 자기 자신의 게임 오브젝트를 파괴합니다.
        {
            // 씬 이동이 되었는데 이동한 씬에도 Singleton객체가 존재할 수 있기 때문에 중복되지 않도록 삭제합니다.
            Destroy(this.gameObject);
        }

        // 게임 오브젝트를 다른 씬으로 함께 이동시킬 수 있는 함수입니다.
        // 씬을 이동할 때 게임 오브젝트가 파괴되지 않고 그대로 이동할 수 있도록 유지해줍니다.
        DontDestroyOnLoad(gameObject);
    }



}  
