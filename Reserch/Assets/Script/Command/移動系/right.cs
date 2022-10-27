using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Right : Command
{

    public Right(GameObject characterObj) :base(characterObj)
    {
        name = "right";
        Image = Resources.Load<Sprite>("Images/right");
    }

    public override void excute()
    {

        if (MoveSciprt.canMove(new Vector2Int(1, 0)))
        {
            MoveSciprt.right();
            CharacterScript.State.setState(CharacterState.State.MOVE);
        }
        else
        {
            //CharacterScript.finishMoveReqToManager();
        }
    }
}
