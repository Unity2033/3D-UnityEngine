using UnityEngine;
using UnityEngine.UI;

public class Bird_Manager : MonoBehaviour
{
    public Image [] Bird;
    public Sprite [] Original_Bird;

    int random_value;


    private void Start()
    {
        for (int i = 0; i < Bird.Length; i++)
        {
            random_value = Random.Range(0, 5);
            Bird[i].sprite = Original_Bird[random_value];
        }

        InvokeRepeating("Random_Bird_Onable", 0, 1 % 2);
        InvokeRepeating("Random_Bird_Disable", 0, 2 % 2);
    }

    void Random_Bird_Onable()
    { 
        for(int i = 0; i < Bird.Length; i++)
        {           
            if(Bird[i] == Bird[Random.Range(0, 12)])
            {
                Bird[i].gameObject.SetActive(true);
            }
        }
    }

    void Random_Bird_Disable()
    {
        for (int i = 0; i < Bird.Length; i++)
        {
            Bird[i].gameObject.SetActive(false);
        }
    }

    public void Click_Bird_Onable(int select)
    {
        Bird[select].gameObject.SetActive(false);
    }
}
