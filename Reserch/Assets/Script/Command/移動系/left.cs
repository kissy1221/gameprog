using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Left : Command
{
    public Left(GameObject characterObj) :base(characterObj)
    {
        name = "left";
        Image = Resources.Load<Sprite>("Images/left");
    }
    public override void excute()
    {

        if (MoveSciprt.canMove(new Vector2Int(-1, 0)))
        {
           MoveSciprt.left();
            CharacterScript.State.setState(CharacterState.State.MOVE);
        }
        else
        {
            CharacterScript.finishMoveReqToManager();
        }
    }
}
