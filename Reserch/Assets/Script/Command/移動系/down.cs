using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using Const;

public class Down : Command
{
    public Down(GameObject characterObj) :base(characterObj)
    {
        name = "down";
        Image = Resources.Load<Sprite>("Images/down");
    }

    public override async UniTask excute()
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

        await UniTask.Delay((int)(CO.COMMAND_WAIT_TIME * 1000));
    }
}
