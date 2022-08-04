using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Scriptable Object/Item", order = 0)]
public class Item : ScriptableObject
{
    public int price;
    public string name;
    public Sprite picture;
    public Sprite outline;
}
