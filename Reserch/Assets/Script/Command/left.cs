using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Left : Command
{
    public Left(Character character) :base(character)
    {
        name = "left";
        Image = Resources.Load<Sprite>("Images/left");
    }
    public override void excute()
    {
        if(map.canMove(CharacterScript, new Vector2Int(-1,0)))
        {
            map.move(CharacterScript, new Vector2Int(-1, 0));

            CharacterScript.left();
            CharacterScript.movement = true;
        }
        else
        {
            CharacterScript.finishMoveReqToManager();
        }
    }
}
