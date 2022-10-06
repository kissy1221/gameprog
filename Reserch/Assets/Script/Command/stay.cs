using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stay : Command
{
    public stay(string charTag) : base(charTag)
    {
        name = "left";
        Image = Resources.Load<Sprite>("Images/stay");
    }

    public override void excute()
    {
        CharacterScript.finishMoveReqToManager();
    }
}
