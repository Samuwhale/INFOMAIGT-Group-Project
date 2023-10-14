using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boots : Item
{
    public override void LevelUp()
    {
        //float currSpeed;
        switch (level)
        {
            case 0:
                itemOwner.IncreaseMovementSpeed(40);
                break;
            case 1:
                itemOwner.IncreaseMovementSpeed(40);
                //currSpeed = itemOwner.GetMovementSpeed();
                //itemOwner.IncreaseMovementSpeed(Mathf.RoundToInt(currSpeed * 1.1f - currSpeed));
                break;
            case 2:
                itemOwner.IncreaseMovementSpeed(40);
                break;
            case 3:
                itemOwner.IncreaseMovementSpeed(40);
                break;
            case 4:
                itemOwner.IncreaseMovementSpeed(40);
                break;
            default:
                break;
        }
        level++;
    }
}
