using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Down : Command
{
    public Down(GameObject characterObj) :base(characterObj)
    {
        name = "down";
        Image = Resources.Load<Sprite>("Images/down");
    }

    public override void excute()
    {
        if (MoveSciprt.canMove(new Vector2Int(0, 1)))
        {
            MoveSciprt.down();
            CharacterScript.State.setState(CharacterState.State.MOVE);
        }
        else
        {
            //CharacterScript.finishMoveReqToManager();
        }
    }
}
