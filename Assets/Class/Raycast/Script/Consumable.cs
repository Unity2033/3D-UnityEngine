using UnityEngine;
using UnityEngine.UI;

public class Consumable : MonoBehaviour
{
    [SerializeField] Image outline;
    [SerializeField] Image picture;
    [SerializeField] Item item;

    private void Start()
    {
        picture.sprite = item.picture;
        outline.sprite = item.outline;
    }
}
