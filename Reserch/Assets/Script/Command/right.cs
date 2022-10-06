using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Right : Command
{

    public Right(string charTag):base(charTag)
    {
        name = "right";
        Image = Resources.Load<Sprite>("Images/right");
    }

    public override void excute()
    {
        if(map.canMove(charTag, new Vector2Int(1, 0)))
        {
            map.move(charTag, new Vector2Int(1, 0));

            CharacterScript.right();
            CharacterScript.movement = true;
        }
        else
        {
            CharacterScript.finishMoveReqToManager();
        }
    }
}
