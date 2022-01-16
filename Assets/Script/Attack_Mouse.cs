using UnityEngine;

public class Attack_Mouse : MonoBehaviour
{
    [SerializeField] GameObject Bomb;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit Hit;

            Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out Hit,Mathf.Infinity))
            {
                Instantiate(Bomb, Hit.transform.position,Quaternion.identity);
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            GameObject Bomb_Clone = GameObject.Find("Bomb(Clone)");
            Destroy(Bomb_Clone,1);
        }
    }
}
