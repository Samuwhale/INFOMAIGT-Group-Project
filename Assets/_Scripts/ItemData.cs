using UnityEngine;

[CreateAssetMenu(fileName = "Item Data", menuName = "ScriptableObjects/ItemData", order = 2)]
public class ItemData : ScriptableObject
{
    public string itemName;
    public int itemId;
    public Sprite icon;
    public string[] description; // for every level
}
