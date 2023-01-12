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
        //���M�̓Y������T��
        int index = commandList.indexOf(this);
        
        //�����œ��͂��ꂽ����������Ă��邩�̔���
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
        //�΂ɂȂ��Ă���End�R�}���h��T��
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
