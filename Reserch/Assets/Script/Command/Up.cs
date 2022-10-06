using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Up : Command
{

    public Up(string charTag):base(charTag)
    {

        name = "up";
        Image = Resources.Load<Sprite>("Images/up");
    }

    public override void excute()
    {
        if(map.canMove(charTag, new Vector2Int(0, -1)))
        {
            map.move(charTag, new Vector2Int(0, -1));

            CharacterScript.up();
            CharacterScript.movement = true;
        }
        else
        {
            CharacterScript.finishMoveReqToManager();
        }

    }
}
