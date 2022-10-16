using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Down : Command
{
    public Down(Character character) :base(character)
    {
        name = "down";
        Image = Resources.Load<Sprite>("Images/down");
    }

    public override void excute()
    {
        /*
        if(map.canMove(CharacterScript, new Vector2Int(0, 1)))
        {
            //mapì‡ïîèàóù
            map.move(CharacterScript, new Vector2Int(0, 1));

            //ï\ñ èàóù
            CharacterScript.down();
            CharacterScript.movement = true;
        }
        else
        {
            CharacterScript.finishMoveReqToManager();
        }
        */
        if (CharacterScript.canMove(new Vector2Int(0, 1)))
        {
            CharacterScript.down();
            CharacterScript.movement = true;
        }
        else
        {
            CharacterScript.finishMoveReqToManager();
        }
    }
}
