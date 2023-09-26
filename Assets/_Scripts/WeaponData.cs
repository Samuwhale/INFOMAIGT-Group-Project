using UnityEngine;

[CreateAssetMenu(fileName = "Weapon Data", menuName = "ScriptableObjects/WeaponData", order = 1)]
public class WeaponData : ScriptableObject
{
    public string weaponName;
    public int weaponId;
    public Sprite icon;
    public string[] description; // for every level
}