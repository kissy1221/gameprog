using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using Const;

public class BlackOut : Command
{
    public BlackOut(GameObject characterObj) : base(characterObj)
    {

        name = "BlackOut";
        Image = Resources.Load<Sprite>("Images/BlackOutIcon");
    }

    public override async UniTask excute()
    {
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        Player.AddComponent<Blind>();
        await UniTask.Delay((int)(CO.COMMAND_WAIT_TIME * 1000));

    }
}
