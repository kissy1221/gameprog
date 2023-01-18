using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using Const;

public class Swap : Command
{
    public Swap(GameObject characterObj) : base(characterObj)
    {
        date = Resources.Load(CO.PATH.COMMAND_ENEMY + "Swap") as CommandDate;


    }

    public override async UniTask excute()
    {
        commandList.swap(0, 1);
        await UniTask.Delay((int)(CO.COMMAND_WAIT_TIME * 1000));
    }

}
