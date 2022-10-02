using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        commandList = new CommandList("Enemy"); //実行後、コマンドリストのインスタンスを作成

    }

    // Update is called once per frame
    void Update()
    {

        if (!isAction() && GameManager.instance.isRunning())
        {
            commandList.run();
        }

        move();
    }

    //ランダムでリストにコマンドを入れる
    private void pushCommandListAtRondom()
    {
        int CommandNum=Random.Range(1,8);

        for(int i=0;i<CommandNum;i++)
        {
            int RandomNum = Random.Range(1, 5);

            switch(RandomNum)
            {
                case 1:
                    commandList.push("up");
                    break;
                case 2:
                    commandList.push("left");
                    break;
                case 3:
                    commandList.push("right");
                    break;
                    
                case 4:
                    commandList.push("down");
                    break;
            }
        }

    }
}
