using UnityEngine;
using UnityEngine.Video;

public class Picking : MonoBehaviour
{
    public LayerMask layer;
    private RaycastHit hit;
    private Texture2D cursor;
    private VideoPlayer video;

    private void Start()
    {
        video = GameObject.Find("Screen").GetComponent<VideoPlayer>();

        cursor = Resources.Load<Texture2D>("Basic");
        Cursor.SetCursor(cursor, new Vector2(0, 0), CursorMode.Auto);
      
    }

    void Update()
    {  
        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // 광선을 발사한 다음 광선과 충돌한 게임 오브젝트가 있다면 hit 변수에 데이터를 저장합니다.  
            if (Physics.Raycast(ray, out hit)) // layer는 해당 layer만 검출하여 충돌을 처리합니다.
            {
                video.Play();
            }
        }    
    }
}



