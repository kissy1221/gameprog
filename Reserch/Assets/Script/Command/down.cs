using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Down : Command
{
    public Down(string charTag):base(charTag)
    {
        name = "down";
        Image = Resources.Load<Sprite>("Images/down");
    }

    public override void excute()
    {
        CharacterScript.down();
        CharacterScript.movement = true;
    }
}
