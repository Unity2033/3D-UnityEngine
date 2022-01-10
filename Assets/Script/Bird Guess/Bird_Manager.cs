using UnityEngine;
using UnityEngine.UI;

public class Bird_Manager : MonoBehaviour
{
    public Image [] Bird;
    public Text [] Whether;
    public Sprite[] Original_Bird;
    public Text Result_Success, Result_Failure;

    public int score;
    public int Success_count, Failure_count;

    int random_value;
    int answer_value;

    private void Start()
    {
        for (int i = 0; i < Bird.Length; i++)
        {
            random_value = Random.Range(0, 5);
            Bird[i].gameObject.SetActive(false);
            Bird[i].sprite = Original_Bird[random_value];
        }

        InvokeRepeating("Random_Bird_Onable", 1, 1);
    }

    private void Update()
    {
        Result_Success.text = "Success : " + Success_count.ToString();
        Result_Failure.text = "Failure : " + Failure_count.ToString();
    }

    void Random_Bird_Onable()
    {
        Invoke("Random_Bird_Disable", 1);

        for (int i = 0; i < Bird.Length; i++)
        {
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

    void Whether_Disable()
    {
        for (int i = 0; i < Bird.Length; i++)
        {
            Whether[i].gameObject.SetActive(false);                
        }
    }

    public void Click_Bird_Onable(int select)
    {
        if (Time.timeScale > 0)
        {
            Sound_System.instance.Failure_Sound();
            Whether[select].gameObject.SetActive(true);

            Invoke("Whether_Disable", 0.25f);

            if (score < 0) score = 0;

            if (answer_value == select)
            {
                score += 10;
                Success_count++;
                answer_value = -1;
                Whether[select].text = "Success";
                Whether[select].color = new Color(0, 255, 0);
            }
            else
            {
                score -= 10;
                Failure_count++;
                Whether[select].text = "Failure";
                Whether[select].color = new Color(255, 0, 0);
            }

            Bird[select].gameObject.SetActive(false);
        }
    }


}
