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
        int index = commandList.indexOf(this);

        if(index+1<commandList.Count)
        {
            Command com = commandList.getFrom(index + 1);
            await com.excute();
            commandList.removeAt(index + 1);
        }

    }
}
