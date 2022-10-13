using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Right : Command
{

    public Right(Character character) :base(character)
    {
        name = "right";
        Image = Resources.Load<Sprite>("Images/right");
    }

    public override void excute()
    {
        if(map.canMove(CharacterScript, new Vector2Int(1, 0)))
        {
            map.move(CharacterScript, new Vector2Int(1, 0));

            CharacterScript.right();
            CharacterScript.movement = true;
        }
        else
        {
            CharacterScript.finishMoveReqToManager();
        }
    }
}
