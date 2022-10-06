using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Left : Command
{
    public Left(string charTag):base(charTag)
    {
        name = "left";
        Image = Resources.Load<Sprite>("Images/left");
    }
    public override void excute()
    {
        if(map.canMove(charTag,new Vector2Int(-1,0)))
        {
            map.move(charTag, new Vector2Int(-1, 0));

            CharacterScript.left();
            CharacterScript.movement = true;
        }
        else
        {
            CharacterScript.finishMoveReqToManager();
        }
    }
}
