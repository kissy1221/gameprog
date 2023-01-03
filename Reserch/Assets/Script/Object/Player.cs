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

        if(Input.GetKeyDown(KeyCode.F))
        {
            commandList.Add(new If(this.gameObject));
        }
        if(Input.GetKeyDown(KeyCode.E))
        {
            commandList.Add(new End(this.gameObject));
        }

        if(Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log("構文チェック結果:" + commandList.checkSynax());
        }

    }


}
