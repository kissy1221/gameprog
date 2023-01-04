using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class BattleManager : SingletonMonoBehaviour<BattleManager>
{
    public SelectableList<Command> List = new SelectableList<Command>();

    [SerializeField] Player player;
    [SerializeField] EnemyManager enemyManager;


    // Start is called before the first frame update
    void Start()
    {
        List.mChanged += () => excute();
    }

    // Update is called once per frame
    void Update()
    {
        
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
            return true;

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

        return sortList;

    }

    async UniTask excute()
    {
        if(checkReceiveCommand())
        {
            List<Command> sortList = Sort();
            string str = "";
            foreach(Command com in sortList)
            {
                str += com.date.name + "=>";
            }
            Debug.Log(str);

            foreach(Command com in sortList)
            {
                com.getExcuteObject().GetComponent<Character>().ExcuteCommandAsync();
            }

            List.ClearWithoutCallback();

        }

    }

}
