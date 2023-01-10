using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using Const;
    
public class If : Command
{
    public If(GameObject characterObj) : base(characterObj)
    {
        date = Resources.Load(CO.PATH.COMMAND_BACKBORNE + "If") as CommandDate;
    }

    public override async UniTask excute()
    {
        //Ž©M‚Ì“Y‚¦Žš‚ð’T‚·
        int index = commandList.indexOf(this);
        
        //‚±‚±‚Å“ü—Í‚³‚ê‚½ðŒ‚ª‰ï‚Á‚Ä‚¢‚é‚©‚Ì”»’è
        if(!(false))
        {
            skip();
        }

        //await UniTask.WaitUntil(() => Input.GetKeyDown(KeyCode.O));

        Command com = commandList.getFrom(index + 1);
        await com.excute();
        commandList.removeAt(index + 1);

        //await UniTask.Delay((int)(CO.COMMAND_WAIT_TIME * 1000));
    }

    void skip()
    {
        //‘Î‚É‚È‚Á‚Ä‚¢‚éEndƒRƒ}ƒ“ƒh‚ð’T‚·
        int suz=1; 

        while(true)
        {
            Command com = commandList.getFrom(1);
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
                commandList.removeAt(1);
            }

        }
    }
}
