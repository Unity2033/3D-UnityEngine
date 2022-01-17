using UnityEngine;

class Monster_State
{
    public int Health = 100;
}

public class Attack_Mouse : MonoBehaviour
{
    Monster_State monster_state = new Monster_State();
    [SerializeField] GameObject Bomb;
    List_Object_Pool list_pool;

    private void Awake()
    {
        list_pool = new List_Object_Pool(Bomb);

    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit Hit;

            Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out Hit,Mathf.Infinity,1 << LayerMask.NameToLayer("Monster")))
            {
                monster_state.Health -= 100;
                Bomb.transform.position = Hit.transform.position;
                Bomb = list_pool.Active_Object();
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            list_pool.Deactivate_Object(Bomb);
        }
    }
}
