using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Up : Command
{

    public Up(string charTag):base(charTag)
    {

        name = "up";
        Image = Resources.Load<Sprite>("Images/up");
    }

    public override void excute()
    {
        CharacterScript.up();
        CharacterScript.movement = true;
    }
}
