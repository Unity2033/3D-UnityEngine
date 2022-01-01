using UnityEngine;
using UnityEngine.UI;

public class Bird_Manager : MonoBehaviour
{
    public Image [] Bird;
    public Text [] Whether;
    public Sprite [] Original_Bird;

    public int score;

    int random_value;
    int answer_value;

    float count = 0;

    private void Start()
    {
        for (int i = 0; i < Bird.Length; i++)
        {
            random_value = Random.Range(0, 5);
            Bird[i].sprite = Original_Bird[random_value];
        }

        InvokeRepeating("Random_Bird_Onable", 0, 1);
        InvokeRepeating("Random_Bird_Disable", 0, 1.5f);
    }

    private void Update()
    {
        count += Time.deltaTime;

        if (count > 0.5f)
        {
            for (int i = 0; i < Whether.Length; i++)
            {
                Whether[i].gameObject.SetActive(false);
            }

            count = 0.0f;
        }
    }

    void Random_Bird_Onable()
    {
        for (int i = 0; i < Bird.Length; i++)
        {
            Whether[i].gameObject.SetActive(false);

            if (Bird[i] == Bird[Random.Range(0, 12)])
            {              
                Bird[i].gameObject.SetActive(true);
                answer_value = i;
                return;
            }
        }
    }

    void Random_Bird_Disable()
    {
        answer_value = -1;

        for (int i = 0; i < Bird.Length; i++)
        {
            Bird[i].gameObject.SetActive(false);        
        }
    }

    public void Click_Bird_Onable(int select)
    {
        Whether[select].gameObject.SetActive(true);

        if (answer_value == select)
        {
            score += 10;
            answer_value = -1;
            Whether[select].text = "Success";
            Whether[select].color = new Color(0, 255, 0);
        }
        else
        {
            score -= 5;
            Whether[select].text = "Failure";
            Whether[select].color = new Color(255, 0, 0);
        }

        Bird[select].gameObject.SetActive(false);
    }
}
