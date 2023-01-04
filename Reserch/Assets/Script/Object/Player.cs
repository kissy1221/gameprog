using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    new private void Start()
    {
        base.Start();

    }
    new void Update()
    {

        base.Update();

        if(Input.GetKeyDown(KeyCode.I))
        {
            commandList.Add(new If(this.gameObject));
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            commandList.Add(new End(this.gameObject));
        }


    }


}
