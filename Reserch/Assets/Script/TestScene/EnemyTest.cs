using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class EnemyTest : CharacterTest
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

    public override async UniTask excute(int time)
    {
        status = State.EXCUTE;
        Allow = false;

        gage.setTime(time);
        descriputionText.text = time + "•bŠÔŽÀs’†‚·‚é";

        await UniTask.Delay(time * 1000);

        status = State.WAIT;

        descriputionText.text = "";
    }

    public async UniTask chart()
    {
        for (int i = 3; i > 0; i--)
        {
            await UniTask.WaitUntil(() => Allow);
            await excute(i);
        }

        status = State.FINISH;
    }

    public async UniTask chart1()
    {
        await UniTask.WaitUntil(() => Allow);
        await excute(1);

        await UniTask.WaitUntil(() => Allow);
        await excute(1);

        await UniTask.WaitUntil(() => Allow);
        await excute(1);

        await UniTask.WaitUntil(() => Allow);
        await excute(1);

        status = State.FINISH;
    }

    public async UniTask chart2()
    {
        for(int i=0;i<2;i++)
        {
            await UniTask.WaitUntil(() => Allow);
            await excute(i + 1);
        }
        status = State.FINISH;

    }

}
