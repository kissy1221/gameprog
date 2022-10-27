using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swap : Command
{
    public Swap(GameObject characterObj) : base(characterObj)
    {
        Image = Resources.Load<Sprite>("Images/swapIcon");

    }

    public override void excute()
    {
        commandList.swap(1, 2);
    }

}
