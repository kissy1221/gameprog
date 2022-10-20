using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Up : Command
{

    public Up(GameObject characterObj) :base(characterObj)
    {

        name = "up";
        Image = Resources.Load<Sprite>("Images/up");
    }

    public override void excute()
    {
        if (MoveSciprt.canMove(new Vector2Int(0, -1)))
        {
            MoveSciprt.up();
            CharacterScript.State.setState(CharacterState.State.MOVE);
        }
        else
        {
            Debug.Log("“®‚¯‚Ü‚¹‚ñ");
            CharacterScript.finishMoveReqToManager();
        }

    }
}
