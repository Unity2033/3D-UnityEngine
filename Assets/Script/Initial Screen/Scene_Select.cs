using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Select : MonoBehaviour
{
    public void Scene_Number(int number) // 매개변수를 생성하면 인스펙터에서 매개변수를 입력 할 수 있습니다.
    {
        Sound_System.instance.Scene_Sound();
        SceneManager.LoadScene(number); // 씬을 불러오는 함수로 Scenes in Build에 설정된 값에 따라 이동합니다.
    }
}
