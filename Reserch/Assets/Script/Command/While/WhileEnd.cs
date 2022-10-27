using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhileEnd : Command
{
    public WhileEnd(GameObject characterObj) : base(characterObj)
    {
        Image = Resources.Load<Sprite>("Images/tentative");

    }

    public override void excute()
    {

    }
}
