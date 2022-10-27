using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhileStart : Command
{
    public WhileStart(GameObject characterObj) : base(characterObj)
    {
        Image = Resources.Load<Sprite>("Images/tentative");

    }

    public override void excute()
    {
        commandList.swap(1, 2);
    }
}
