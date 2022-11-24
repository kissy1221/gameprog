using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{


    private void Start()
    {
        base.Start();


    }
    void Update()
    {

        base.Update();


        if(Input.GetKeyDown(KeyCode.S))
        {
            //commandList.add(new WarpSword(this.gameObject));
            commandList.add(new Mine(this.gameObject));
        }
        if(Input.GetKeyDown(KeyCode.B))
        {
            commandList.add(new BlackOut(this.gameObject));
        }

    }


}
