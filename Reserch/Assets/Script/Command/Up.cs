using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Up : Command
{

    public Up(Character character) :base(character)
    {

        name = "up";
        Image = Resources.Load<Sprite>("Images/up");
    }

    public override void excute()
    {
        /*
        if(map.canMove(CharacterScript, new Vector2Int(0, -1)))
        {
            map.move(CharacterScript, new Vector2Int(0, -1));

            CharacterScript.up();
            CharacterScript.movement = true;
        }
        else
        {
            CharacterScript.finishMoveReqToManager();
        }
        */

        if (CharacterScript.canMove(new Vector2Int(0, -1)))
        {
            
            CharacterScript.up();
            CharacterScript.movement = true;
        }
        else
        {
            CharacterScript.finishMoveReqToManager();
        }

    }
}
