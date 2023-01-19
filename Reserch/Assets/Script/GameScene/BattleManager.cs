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
        List.mChanged += () => testMethod();//�R�[���o�b�N�֐��o�^
    }

    //�S������R�}���h���󂯎�������̔���
    public bool checkReceiveCommand()
    {
        int CharacterNum = GameObject.FindGameObjectsWithTag("Player").Length + GameObject.FindGameObjectsWithTag("Enemy").Length;//�L�����N�^�[�����݂��鐔
        int FinishNum=0;//�R�}���h���I�����Ă���l�̐�

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

    //�D�揇�ʂ����߂�(�\�[�g)
    List<Command> Sort()
    {

        List<Command> sortList = new List<Command>();

        //��R�}���h��}���
        foreach(Command com in List)
        {
            if (com.date.type == CommandDate.commandType.Backbone)
                sortList.Add(com);
        }

        //�T�|�[�g�R�}���h������
        foreach (Command com in List)
        {
            if (com.date.type == CommandDate.commandType.Support)
                sortList.Add(com);
        }

        //�U���R�}���h��}���
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
            Debug.Log($"---�X�e�b�v{step}---");
            List<Command> sortList=Sort();
            List<UniTask> taskList=new List<UniTask>();

            foreach(Command com in sortList)
            {
                Debug.Log($"{com.getExcuteObject()}�����s");
                if(com.getExcuteObject()!=null)
                    taskList.Add(com.excute());
            }
            state = BattleManagerState.EXCUTE;


            await UniTask.WhenAll(taskList.ToArray());
            Debug.Log($"---�X�e�b�v{step}�I��---");
            List.ClearWithoutCallback();
            state = BattleManagerState.WAIT;
            Debug.Log("���X�e�b�v");


        }
    }

}
