using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Down : Command
{
    public Down(string charTag):base(charTag)
    {
        name = "down";
        Image = Resources.Load<Sprite>("Images/down");
    }

    public override void excute()
    {
        if(map.canMove(charTag, new Vector2Int(0, 1)))
        {
            //map内部処理
            map.move(charTag, new Vector2Int(0, 1));

            //表面処理
            CharacterScript.down();
            CharacterScript.movement = true;
        }
        else
        {
            CharacterScript.finishMoveReqToManager();
        }
    }
}
