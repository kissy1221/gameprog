using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using Const;

public class Up : Command
{

    public Up(GameObject characterObj) :base(characterObj)
    {
        date = Resources.Load(CO.PATH.COMMAND_BACKBORNE + "Up") as CommandDate;
    }

    public override async UniTask excute()
    {
        if (MoveSciprt.canMove(new Vector2Int(0, -1)))
        {
            MoveSciprt.up();
            CharacterScript.State.setState(CharacterState.State.MOVE);
            
        }

        await UniTask.Delay((int)(CO.COMMAND_WAIT_TIME * 1000));

    }
}
