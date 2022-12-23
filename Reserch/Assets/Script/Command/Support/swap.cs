using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using Const;

public class Swap : Command
{
    public Swap(GameObject characterObj) : base(characterObj)
    {
        Image = Resources.Load<Sprite>("Images/swapIcon");

    }

    public override async UniTask excute()
    {
        commandList.swap(1, 2);
        await UniTask.Delay((int)(CO.COMMAND_WAIT_TIME * 1000));
    }

}
