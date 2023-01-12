using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using Const;

public class stay : Command
{
    public stay(GameObject characterObj) : base(characterObj)
    {
        date = Resources.Load(CO.PATH.COMMAND_BACKBORNE + "Stay") as CommandDate;

    }

    public override async UniTask excute()
    {
        await UniTask.Delay((int)(CO.COMMAND_WAIT_TIME * 1000));
        //CharacterScript.finishMoveReqToManager();
    }
}
