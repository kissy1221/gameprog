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

        if(0<commandList.Count)
        {
            Command com = commandList.getFrom(0);
            commandList.removeAt(0);
            await com.excute();
            
        }

    }
}
