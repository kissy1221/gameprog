using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using Cysharp.Threading.Tasks;
using UnityEngine.Events;

public class PlayerTest : CharacterTest
{
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
    }

    //1��̏���
    public override async UniTask excute(int time)
    {
        status = State.EXCUTE;
        Allow = false;

        gage.setTime(time); //�����Ɋ֌W�Ȃ�
        descriputionText.text = time + "�b�Ԏ��s������";
        await UniTask.Delay(time*1000); //�R�}���h�̎��s

        status = State.WAIT;
        descriputionText.text ="";
    }

    public async UniTask Chart()
    {
        /*
        for(int i=0;i<3;i++)
        {
            await UniTask.WaitUntil(() => Allow);
            await excute(i + 1);
        }
        */
        await UniTask.WaitUntil(() => Allow);
        await excute(1);


        status = State.FINISH;
    }
}
