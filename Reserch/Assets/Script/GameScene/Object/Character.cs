using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;
using Const;

public class Character : Object
{

    protected CommandList commandList; //自身の所持しているコマンドリスト
    protected List<Condition> status = new List<Condition>();
    public CharacterState State = new CharacterState();

    Image conditionImage;

    [HideInInspector] public Vector2Int beforePos; //以前のコマンドのときにいたポジション



    

    public enum CommandState
    {
        START,
        WAIT,
        EXCUTE,
        FINISH
    }

    public CommandState commandStatus;


    protected override void Start()
    {
        base.Start();

        commandList = GetComponent<CommandList>();
    }

    protected override void Update()
    {
        base.Update();

        if (GameManager.instance.State != GameManager.gameState.Run)
            commandStatus = CommandState.START;

    }


    public virtual async UniTask run()
    {
        commandStatus = CommandState.START;
        GameManager.instance.switchRun(true);

        //構文チェック
        if(commandList.checkSynax())
        {
            while (commandList.Count > 0)
            {

                beforePos = this.gameObject.getMapPosition();//コマンド実行前にポジションの履歴を記録


                sendCommandtoBattleManager();//コマンドをバトルマネージャーに渡す
                await UniTask.WaitUntil(() => BattleManager.Instance.state == BattleManager.BattleManagerState.EXCUTE); //バトルマネージャーが実行するまで待機
                
                //次のコマンドがある場合
                if (commandList.Count>0)
                {
                    commandStatus = CommandState.WAIT; //待機
                    //Debug.Log($"{name}=>コマンドがあるので待機します");
                    await UniTask.WaitUntil(() => BattleManager.Instance.state==BattleManager.BattleManagerState.WAIT); //バトルマネージャーが実行終了するまで待機
                }
                
            }
        }

        //コマンドが終了したことを記載
        commandStatus = CommandState.FINISH;
        Debug.Log($"{name}=>コマンド終了！");
        beforePos = this.gameObject.getMapPosition();

    }

    public void sendCommandtoBattleManager()
    {
        Command com = commandList.getFrom(0);//先頭を参照
        Debug.Log($"{name }=>{com.date.name}を渡します");
        commandList.removeHead();//先頭を外す
        BattleManager.Instance.List.Add(com);//渡す
        
    }

    protected override void Death()
    {
        base.Death();
        commandList.clear();
    }

    //
    void showCondition()
    {
        
    }



}
