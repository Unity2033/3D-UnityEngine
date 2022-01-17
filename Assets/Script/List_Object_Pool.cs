using UnityEngine;
using System.Collections.Generic;

public class List_Object_Pool : MonoBehaviour
{
    class Memory
    {
        public bool active;             // 게임 오브젝트의 활성화,비활성화 정보
        public GameObject gameobject;   // 메모리에 저장할 게임 오브젝트
    }

    int increase_count = 5;             // 게임 오브젝트가 부족할 때 Instantiate()로 추가 생성되는 오브젝트의 수
    int max_count;                      // 현재 리스트에 등록되어 있는 오브젝트의 수
    int active_count;                   // 현재 게임에 사용되고 있는(활성화) 오브젝트의 수

    GameObject pool_object;             // 오브젝트 풀링에서 관리하는 게임 오브젝트의 프리팹
    List<Memory> pool_memory;           // 관리되는 모든 오브젝트를 저장하는 리스트

    public List_Object_Pool(GameObject pool_gameobject)
    {
        max_count = 0;
        active_count = 0;
        pool_object = pool_gameobject;

        pool_memory = new List<Memory>();

        Instantiate_Objects();
    }
    
    // increase_count 단위로 오브젝트를 생성하는 함수
    public void Instantiate_Objects() 
    {
        max_count += increase_count;                                 // 오브젝트의 수를 increase_count 만큼 증가시킵니다.

        for (int i =0; i < increase_count; ++i)
        {
            Memory memory = new Memory();

            memory.active = false;
            memory.gameobject = GameObject.Instantiate(pool_object); // 게임 오브젝트를 생성합니다.
            memory.gameobject.SetActive(false);

            pool_memory.Add(memory);                                  // 생성된 게임 오브젝트를 리스트에 저장합니다.
        }
    }

    public GameObject Active_Object()
    {
        if (pool_memory == null) return null;

        // 현재 생성해서 관리하는 모든 게임 오브젝트의 수와 현재 활성화 상태인 게임 오브젝트의 수를 비교합니다.
        // 모든 오브젝트가 활성화 상태이면 새로운 오브젝트가 필요합니다.       
        if(max_count == active_count)
        {
            Instantiate_Objects();
        }

        int count = pool_memory.Count;

        for(int i = 0; i < count; ++i)
        {
            Memory memory = pool_memory[i];

            if(memory.active == false)
            {
                active_count++;

                memory.active = true;
                memory.gameobject.SetActive(true);

                return memory.gameobject;
            }
        }

        return null;
    }

    // 현재 사용이 완료된 오브젝트를 비활성화 상태로 설정하는 함수
    public void Deactivate_Object(GameObject remove_object)
    {
        if (pool_memory == null || remove_object == null) return;

        int count = pool_memory.Count;

        for(int i = 0; i < count; ++i)
        {
            Memory memory = pool_memory[i];

            if(memory.gameobject == remove_object)
            {
                active_count--;

                memory.active = false;
                memory.gameobject.SetActive(false);

                return;
            }
        }
    }
}
