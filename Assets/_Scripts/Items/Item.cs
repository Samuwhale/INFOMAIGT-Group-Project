using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    protected CharacterBase itemOwner;
    
    public int level;
    public ItemData itemData;

    private void Awake()
    {
        level = 0;
    }

    private void InitializeItemValues()
    {
        itemOwner = GetComponent<CharacterBase>();
    }

    public abstract void LevelUp();

    public void Activate()
    {
        InitializeItemValues();
        
        Debug.Log($"Item {this} activated");
    }
}
