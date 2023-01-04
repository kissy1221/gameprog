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

    public Vector2Int beforePos; //以前のコマンドのときにいたポジション


    new protected void Start()
    {
        base.Start();

        commandList = GetComponent<CommandList>();
    }

    new protected void Update()
    {
        base.Update();

        if (GameManager.instance.State != GameManager.gameState.Run)
            commandStatus = CommandState.START;

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

                beforePos = this.gameObject.getMapPosition();//コマンド実行前にポジションの履歴を記録

                await ExcuteCommandAsync(); //コマンド実行

                //次のコマンドがある場合
                if(commandList.Count>0)
                {
                    commandStatus = CommandState.WAIT; //待機
                }
                
            }
        }

        //コマンドが終了したことを記載
        commandStatus = CommandState.FINISH;
        beforePos = this.gameObject.getMapPosition();


    }
    public async UniTask ExcuteCommandAsync()
    {
        commandStatus = CommandState.EXCUTE;

        CommandAllow = false;
        Command com = commandList.getFrom(0);//先頭を参照
        
        Debug.Log(this.gameObject.name+"=>"+com.date.name+"を実行！");
        await com.excute(); //コマンドが終了するまで待つ

        commandList.removeHead();//先頭を外す
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
