using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class BattleManager : SingletonMonoBehaviour<BattleManager>
{
    public SelectableList<Command> List = new SelectableList<Command>();

    public enum BattleManagerState
    {
        WAIT,
        SORT,
        EXCUTE
    }

    public BattleManagerState state = BattleManagerState.WAIT;


    [SerializeField] Player player;
    [SerializeField] EnemyManager enemyManager;
    public int step=0;


    // Start is called before the first frame update
    void Start()
    {
        List.mChanged += () => testMethod();//コールバック関数登録
    }

    //全員からコマンドを受け取ったかの判定
    public bool checkReceiveCommand()
    {
        int CharacterNum = GameObject.FindGameObjectsWithTag("Player").Length + GameObject.FindGameObjectsWithTag("Enemy").Length;//キャラクターが存在する数
        int FinishNum=0;//コマンドを終了している人の数

        if(player.commandStatus==Character.CommandState.FINISH)
        {
            FinishNum++;
        }

        foreach(GameObject enemy in enemyManager.Enemies)
        {
            Enemy en=enemy.GetComponent<Enemy>();
            if(en.commandStatus==Character.CommandState.FINISH)
            {
                FinishNum++;
            }
            
        }

        if (List.Count == CharacterNum - FinishNum)
        {
            return true;
        }
            

        return false;
    }

    //優先順位を決める(ソート)
    List<Command> Sort()
    {

        List<Command> sortList = new List<Command>();

        //基幹コマンドを挿れる
        foreach(Command com in List)
        {
            if (com.date.type == CommandDate.commandType.Backbone)
                sortList.Add(com);
        }

        //サポートコマンドを入れる
        foreach (Command com in List)
        {
            if (com.date.type == CommandDate.commandType.Support)
                sortList.Add(com);
        }

        //攻撃コマンドを挿れる
        foreach (Command com in List)
        {
            if (com.date.type == CommandDate.commandType.Atack)
                sortList.Add(com);
        }

        List.ClearWithoutCallback();
        return sortList;

    }

    public async void testMethod()
    {
        if (checkReceiveCommand())
        {
            step++;
            Debug.Log($"---ステップ{step}---");
            List<Command> sortList=Sort();
            List<UniTask> taskList=new List<UniTask>();

            foreach(Command com in sortList)
            {
                Debug.Log($"{com.getExcuteObject()}が実行");
                if(com.getExcuteObject()!=null)
                    taskList.Add(com.excute());
            }
            state = BattleManagerState.EXCUTE;


            await UniTask.WhenAll(taskList.ToArray());
            Debug.Log($"---ステップ{step}終了---");
            List.ClearWithoutCallback();
            state = BattleManagerState.WAIT;
            Debug.Log("次ステップ");


        }
    }

}
