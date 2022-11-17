using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using Const;

public class Character : Object
{

    public CommandList2 commandList=new CommandList2();

    public CharacterState State = new CharacterState();

    public bool CommandAllow = true; //ゲームマネージャからコマンド実行を許可されたか

    protected void Start()
    {
        base.Start();
    }

    protected void Update()
    {
        base.Update();

        if (State.getState()==CharacterState.State.WAIT && GameManager.instance.isRunning())
        {

            if(CommandAllow)
            {
                run();
            }
            
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
        if(commandList.Count>0)
        {
            ExcuteCommand();

            await UniTask.Delay((int)(CO.COMMAND_WAIT_TIME * 1000));

            //下記よりコマンド動作終了後の動作

            finishMoveReqToManager(); //動作が終了をGMに伝える

            if (commandList.Count <= 0)
            {
                finishReqToManager();
            }
        }
    }

    private void ExcuteCommand()
    {
        CommandAllow = false;
        Command com = commandList.getFrom(0);//先頭を参照
        GameManager.instance.setMoveReq(this.gameObject, false);
        com.excute();
        commandList.removeHead();//先頭を外す
        
    }

    async UniTask ExcuteCommandAsync()
    {
        CommandAllow = false;
        Command com = commandList.getFrom(0);//先頭を参照
        GameManager.instance.setMoveReq(this.gameObject, false);
        com.excute(); //コマンドが終了するまで待つ await記入

        commandList.removeHead();//先頭を外す

        finishMoveReqToManager(); //動作が終了をGMに伝える

        if (commandList.Count <= 0)
        {
            finishReqToManager();
        }
    }
}
