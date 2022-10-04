using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Left : Command
{
    public Left(string charTag):base(charTag)
    {
        name = "left";
        Image = Resources.Load<Sprite>("Images/left");
    }
    public override void excute()
    {
        CharacterScript.left();
        CharacterScript.movement = true;
    }
}
