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
        if (CharacterScript.canMove(new Vector2Int(0, -1)))
        {
            CharacterScript.up();
            CharacterScript.State.setState(CharacterState.State.MOVE);
        }
        else
        {
            Debug.Log("“®‚¯‚Ü‚¹‚ñ");
            CharacterScript.finishMoveReqToManager();
        }

    }
}
