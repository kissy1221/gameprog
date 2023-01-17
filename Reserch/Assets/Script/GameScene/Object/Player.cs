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
            commandList.Add(new If(this.gameObject, commandList.Count));
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            commandList.Add(new End(this.gameObject));
        }
        if(Input.GetKeyDown(KeyCode.W))
        {
            commandList.Add(new Wind(this.gameObject));
        }

        if(Input.GetKeyDown(KeyCode.A))
        {
            status.Add(ConditionDB.Conditions[ConditionID.Poison]);
        }
        if(Input.GetKeyDown(KeyCode.K))
        {
            string str="";

            foreach(Condition cond in status)
            {
                str += cond.Name + ",";
            }

            Debug.Log(str);
        }


    }


}
