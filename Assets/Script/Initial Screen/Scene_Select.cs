using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Scene_Select : MonoBehaviour
{
    public Image Loading;

    public void Scene_Number(int number) // 매개변수를 생성하면 인스펙터에서 매개변수를 입력 할 수 있습니다.
    {
        StartCoroutine(Load_Scene_Process(number));
       // 씬을 불러오는 함수로 Scenes in Build에 설정된 값에 따라 이동합니다.
    }

    IEnumerator Load_Scene_Process(int number)
    {
        AsyncOperation load = SceneManager.LoadSceneAsync(number);
        load.allowSceneActivation = false;

        float timer = 0.0f;

        while(load.isDone)
        {
            yield return null;

            if(load.progress < 0.9f)
            {
                Loading.fillAmount = load.progress;
            }
            else
            {
                timer += Time.unscaledDeltaTime;
                Loading.fillAmount = Mathf.Lerp(0.9f, 1.0f, timer);

                if(Loading.fillAmount >= 1f)
                {
                    load.allowSceneActivation = true;
                    yield break;
                }
            }
        }
    }
    
}
