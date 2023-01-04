using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using Const;

public class Character : Object
{

    protected CommandList commandList;
    public CharacterState State = new CharacterState();

    public bool CommandAllow; //ゲームマネージャからコマンド実行を許可されたか

    public enum CommandState
    {
        START,
        WAIT,
        EXCUTE,
        FINISH
    }

    public CommandState commandStatus;



    new protected void Start()
    {
        base.Start();

        commandList = GetComponent<CommandList>();
    }

    new protected void Update()
    {
        base.Update();

    }


    public virtual async void run()
    {
        commandStatus = CommandState.START;

        GameManager.instance.switchRun(true);

        //構文チェック
        if(commandList.checkSynax())
        {
            while (commandList.Count > 0)
            {
                await UniTask.WaitUntil(() => CommandAllow);
                await ExcuteCommandAsync();
            }
        }

        //コマンドが終了したことを記載
        commandStatus = CommandState.FINISH;


    }
    protected async UniTask ExcuteCommandAsync()
    {
        commandStatus = CommandState.EXCUTE;

        CommandAllow = false;
        Command com = commandList.getFrom(0);//先頭を参照
        await com.excute(); //コマンドが終了するまで待つ

        commandList.removeHead();//先頭を外す
        commandStatus = CommandState.WAIT;
        

    }


    //相手の行動を待たずにコマンドを実行
    //バグあり 使わないこと
    public async void runSelf()
    {
        commandStatus = CommandState.START;

        while (commandList.Count > 0)
        {
            await ExcuteCommandAsync();
        }

        //コマンドが終了したことを記載
        commandStatus = CommandState.FINISH;
    }



}
