using UnityEngine;

public class Sound_System : MonoBehaviour
{
    public static Sound_System instance = null;

    public AudioSource Audio_Source;
    public AudioClip[] sound;

    private void Awake()
    {
        if(null == instance)
        {
            // 클래스 인스턴스가 생성되면 전역변수 instance에 Sound_System이 없다면 넣어주어야 합니다.
            instance = this;
        }
        else
        {
            // 씬 이동이 되었는데 그 씬에도 Sound_System이 존재할 수 있기 때문에 중복되지 않도록 삭제합니다.
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void Failure_Sound()
    {
        Audio_Source.PlayOneShot(sound[0]);
    }

    public void Scene_Sound()
    {
        Audio_Source.PlayOneShot(sound[1]);
    }

    public void Click_Sound()
    {
        Audio_Source.PlayOneShot(sound[2]);
    }
}
