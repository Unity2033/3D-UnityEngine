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
            random_value = Random.Range(0, 5);            // random_value에 0~5 사이에 값을 반환합니다.
            Bird[i].gameObject.SetActive(false);          // 이미지 전체를 비활성화로 설정합니다.
            Bird[i].sprite = Original_Bird[random_value]; // Original_Bird에 랜덤으로 선택된 값을 인덱스에 지정합니다.
        }

        InvokeRepeating("Random_Bird_Onable", 1, 1);       // Random_Bird_Onable 함수를 1초 후에 1초 씩 반복 동작하도록 설정합니다.
    }

    private void Update()
    {
        // ToString()은 어떤 타입을 문자열 타입으로 변환하는 함수입니다.
        Result_Success.text = "Success : " + Success_count.ToString(); 
        Result_Failure.text = "Failure : " + Failure_count.ToString();
    }

    // 랜덤으로 이미지를 활성화하는 함수
    void Random_Bird_Onable()
    {
        Invoke("Random_Bird_Disable", 1); // Random_Bird_Disable() 함수를 1초 후에 실행합니다.

        for (int i = 0; i < Bird.Length; i++)
        {
            if (Bird[i] == Bird[Random.Range(0, 12)]) // 배열의 인덱스와 배열의 랜덤 인덱스가 같다면
            {
                Bird[i].gameObject.SetActive(true);   // 랜덤 인덱스와 같은 배열의 인덱스를 활성화합니다.
                answer_value = i;                     // answer_value 변수에 i 라는 변수를 넣어줍니다.
                return;                               // 한번 활성화하게 되면 if문을 바로 빠져나옵니다.
            }
        }
    }

    // 랜덤 이미지를 비활성화하는 함수
    void Random_Bird_Disable()
    {
        answer_value = -1;

        for (int i = 0; i < Bird.Length; i++)
        {        
            Bird[i].gameObject.SetActive(false);        
        }
    }

    // 텍스트 배열을 비활성화하는 함수 
    void Whether_Disable()
    {
        for (int i = 0; i < Bird.Length; i++)
        {
            Whether[i].gameObject.SetActive(false);                
        }
    }

    // 버튼을 클릭했을 때 내가 선택한 번호가 비활성화되는 함수
    public void Click_Bird_Onable(int select)
    {
        if (Time.timeScale > 0) 
        {
            Sound_System.instance.Failure_Sound();
            Whether[select].gameObject.SetActive(true); // 선택한 번호의 텍스트가 출력됩니다.

            Invoke("Whether_Disable", 0.25f);           // Whether_Disable() 함수가 0.25초 후에 시작됩니다.

            if (score <= 0) // 점수가 0과 같거나 이하로 떨어지면 0으로 고정시키도록 설정
            {
                score = 0;                
            }

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
