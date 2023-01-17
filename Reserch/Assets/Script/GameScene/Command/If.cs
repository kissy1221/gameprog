using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using Const;
    
public class If : Command
{
    int InputIndex;
    public If(GameObject characterObj,int index) : base(characterObj)
    {
        date = Resources.Load(CO.PATH.COMMAND_BACKBORNE + "If") as CommandDate;

        InputIndex = index;
    }

    public override async UniTask excute()
    {
        string search = "Command" + (InputIndex + 1);

        //自身のアイコンオブジェクトを探す
        GameObject commandIcon = commandList.commandListUI.transform.Find(search).gameObject;
        Conditional _conditional = commandIcon.transform.GetChild(0).gameObject.GetComponent<Conditional>();

        //ここで入力された条件が会っているかの判定
        if (!_conditional.checkConditonal())
        {
            //falseの場合
            skip();
        }
        Command com = commandList.getFrom(0);
        commandList.removeAt(0);
        await com.excute();
        

    }

    void skip()
    {
        //対になっているEndコマンドを探す
        int suz=1; 

        while(true)
        {
            Command com = commandList.getFrom(0);

            if (com.GetType() == typeof(If))
            {
                suz++;
            }
            else if (com.GetType() == typeof(End))
            {
                suz--;
            }


            if (suz == 0)
            {
                break;
            }
            else
            {
                commandList.removeAt(0);
            }


        }
    }
}
