using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class WhileStart : Command
{
    public WhileStart(GameObject characterObj) : base(characterObj)
    {
        Image = Resources.Load<Sprite>("Images/tentative");

    }

    public override async UniTask excute()
    {

    }
}
