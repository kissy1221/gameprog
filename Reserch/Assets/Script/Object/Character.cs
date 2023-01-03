using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using Const;

public class Character : Object
{

    //public CommandList2 commandList=new CommandList2();

    protected CommandList commandList;
    public CharacterState State = new CharacterState();
    public bool CommandAllow = true; //ゲームマネージャからコマンド実行を許可されたか

    

    new protected void Start()
    {
        base.Start();

        commandList = GetComponent<CommandList>();
    }

    new protected void Update()
    {
        base.Update();

        //Run中なら
        if (State.getState()==CharacterState.State.WAIT && GameManager.instance.isRunning())
        {
                run();   
        }

    }
    
    public void finishReqToManager()
    {

        GameManager.instance.setFinishReq(this, true);
    }

    //ゲームマネージャーに１つのコマンドが終了を伝える
    public void finishMoveReqToManager()
    {
        GameManager.instance.setMoveReq(this.gameObject,true);
    }


    public async void run()
    {
        if(CommandAllow)
        {
            if (commandList.Count > 0)
            {

                await ExcuteCommandAsync();

            }
            finishMoveReqToManager(); //動作が終了をGMに伝える

            //全コマンドが終了したら
            if (commandList.Count <= 0)
            {
                //コマンド終了をgamemanagerに伝える
                finishReqToManager();
            }
        }
    }
    async UniTask ExcuteCommandAsync()
    {
        CommandAllow = false;
        Command com = commandList.getFrom(0);//先頭を参照
        GameManager.instance.setMoveReq(this.gameObject, false);
        await com.excute(); //コマンドが終了するまで待つ

        commandList.removeHead();//先頭を外す
    }



}
