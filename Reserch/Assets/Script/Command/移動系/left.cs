using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using Const;

public class Left : Command
{
    public Left(GameObject characterObj) :base(characterObj)
    {
        name = "left";
        Image = Resources.Load<Sprite>("Images/left");
    }
    public override async UniTask excute()
    {

        if (MoveSciprt.canMove(new Vector2Int(-1, 0)))
        {
           MoveSciprt.left();
            CharacterScript.State.setState(CharacterState.State.MOVE);
            
        }
        else
        {
            //CharacterScript.finishMoveReqToManager();
        }

        await UniTask.Delay((int)(CO.COMMAND_WAIT_TIME * 1000));
    }
}
