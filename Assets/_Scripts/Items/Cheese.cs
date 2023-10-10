using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheese : Item
{
    public override void LevelUp()
    {
        switch (level)
        {
            case 0:
                itemOwner.IncreaseAttackPower(10);
                itemOwner.IncreaseMaxHealth(10);
                break;
            case 1:
                itemOwner.IncreaseAttackPower(10);
                itemOwner.IncreaseMaxHealth(10);
                break;
            case 2:
                itemOwner.IncreaseAttackPower(10);
                itemOwner.IncreaseMaxHealth(10);
                break;
            case 3:
                itemOwner.IncreaseAttackPower(20);
                itemOwner.IncreaseMaxHealth(20);
                break;
            case 4:
                itemOwner.IncreaseAttackPower(20);
                itemOwner.IncreaseMaxHealth(20);
                break;
            default:
                break;
        }
        level++;
    }
}
