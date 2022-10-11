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
        if(map.canMove(CharacterScript, new Vector2Int(0, 1)))
        {
            //map“à•”ˆ—
            map.move(CharacterScript, new Vector2Int(0, 1));

            //•\–Êˆ—
            CharacterScript.down();
            CharacterScript.movement = true;
        }
        else
        {
            CharacterScript.finishMoveReqToManager();
        }
    }
}
