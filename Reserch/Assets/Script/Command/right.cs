using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Right : Command
{

    public Right(string charTag):base(charTag)
    {
        name = "right";
        Image = Resources.Load<Sprite>("Images/right");
    }

    public override void excute()
    {
        CharacterScript.right();
        CharacterScript.movement = true;
    }
}
