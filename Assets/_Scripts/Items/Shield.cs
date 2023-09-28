using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : Item
{
    public override void LevelUp()
    {
        switch (level)
        {
            case 0:
                itemOwner.IncreaseMaxHealth(10);
                itemOwner.IncreaseDefencePower(10);
                break;
            case 1:
                itemOwner.IncreaseMaxHealth(20);
                break;
            case 2:
                itemOwner.IncreaseDefencePower(20);
                break;
            case 3:
                itemOwner.IncreaseMaxHealth(30);
                break;
            case 4:
                itemOwner.IncreaseDefencePower(30);
                break;
            default:
                break;
        }
        level++;
    }
}
