using UnityEngine;
using UnityEngine.UI;

public class NotificationManager : MonoBehaviour
{
    [SerializeField] Text title;
    [SerializeField] Text content;

    private static GameObject prefab;

    // NotificationManager를 전역에서 접근할 수 있는 함수
    public static NotificationManager NotificationWindow(string titleMessage, string contentMessage)
    {
        if (prefab == null)
        {
            prefab = (GameObject)Resources.Load("Notification Window");
        }

        GameObject obj = Instantiate(prefab);

        NotificationManager resultPopup = obj.GetComponent<NotificationManager>();

        resultPopup.title.text = titleMessage;
        resultPopup.content.text = contentMessage;

        return resultPopup;
    }

    public void CloseWindow()
    {
        Destroy(gameObject);
    }
}
