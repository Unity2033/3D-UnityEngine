using UnityEngine;

public class Create_Monster : MonoBehaviour
{
    Monster_State monster_state = new Monster_State();
    public GameObject Monster;
    List_Object_Pool list_pool;
    float time;

    private void Awake()
    {
        list_pool = new List_Object_Pool(Monster);
    }

    private void Update()
    {
        time += Time.deltaTime;

        if(monster_state.Health <= 0)
        {
            list_pool.Deactivate_Object(Monster);
        }

        if (time >= 5.0f)
        {
            Active_Monster();
            time = 0;
        }
    }


    void Active_Monster()
    {
        Monster.transform.position = new Vector3(Random.Range(-50, 50), 0, 50);
        Monster = list_pool.Active_Object();
    }
}
