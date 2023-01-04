using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using Const;

public class Right : Command
{

    public Right(GameObject characterObj) :base(characterObj)
    {
        date = Resources.Load(CO.PATH.COMMAND_BACKBORNE + "Right") as CommandDate;

    }

    public override async UniTask excute()
    {

        if (MoveSciprt.canMove(new Vector2Int(1, 0)))
        {
            MoveSciprt.right();
            CharacterScript.State.setState(CharacterState.State.MOVE);
            
        }

        await UniTask.Delay((int)(CO.COMMAND_WAIT_TIME * 1000));
    }
}
