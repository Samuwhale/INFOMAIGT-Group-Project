using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheese : Item
{
    public override void LevelUp()
    {
        int currAttack, targetAttack;
        switch (level)
        {
            case 0:
                itemOwner.IncreaseAttackPower(10);
                break;
            case 1:
                currAttack = itemOwner.GetAttackPower();
                targetAttack = Mathf.RoundToInt(currAttack * 1.1f);
                itemOwner.IncreaseMaxHealth(targetAttack - currAttack);
                break;
            case 2:
                currAttack = itemOwner.GetAttackPower();
                targetAttack = Mathf.RoundToInt(currAttack * 1.1f);
                itemOwner.IncreaseMaxHealth(targetAttack - currAttack);
                break;
            case 3:
                currAttack = itemOwner.GetAttackPower();
                targetAttack = Mathf.RoundToInt(currAttack * 1.2f);
                itemOwner.IncreaseMaxHealth(targetAttack - currAttack);
                break;
            case 4:
                currAttack = itemOwner.GetAttackPower();
                targetAttack = Mathf.RoundToInt(currAttack * 1.2f);
                itemOwner.IncreaseMaxHealth(targetAttack - currAttack);
                break;
            default:
                break;
        }
        level++;
    }
}
