using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using Const;

public class stay : Command
{
    public stay(GameObject characterObj) : base(characterObj)
    {
        name = "left";
        Image = Resources.Load<Sprite>("Images/stay");
    }

    public override async UniTask excute()
    {
        await UniTask.Delay((int)(CO.COMMAND_WAIT_TIME * 1000));
        //CharacterScript.finishMoveReqToManager();
    }
}
