using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : Character
{
    private void Start()
    {
        base.Start();
        commandList = new CommandList("Player"); //実行後、コマンドリストのインスタンスを作成

    }
    void Update()
    {
        if(!GameManager.instance.isRunning())
            input();

        if (!isAction() && GameManager.instance.isRunning())
        {
            commandList.run();
        }

        move();

    }

    private void input()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            commandList.push("left");
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            commandList.push("right");
        }

        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            commandList.push("up");
        }
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            commandList.push("down");
        }

        if (Input.GetKeyDown(KeyCode.Delete))
        {
            commandList.pop();
        }

        if(Input.GetKeyDown(KeyCode.Return))
        {
            GameManager.instance.switchRun(true);
        }

        if(Input.GetKeyDown(KeyCode.P))
        {
            commandList.printList();
        }
    }

}
