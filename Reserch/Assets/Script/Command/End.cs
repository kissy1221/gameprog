using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Const;
using Cysharp.Threading.Tasks;

public class End : Command
{
    public End(GameObject characterObj) : base(characterObj)
    {
        date = Resources.Load(CO.PATH.COMMAND_BACKBORNE + "End") as CommandDate;
    }

    public override async UniTask excute()
    {
        await UniTask.Delay((int)(CO.COMMAND_WAIT_TIME * 1000));
    }
}
