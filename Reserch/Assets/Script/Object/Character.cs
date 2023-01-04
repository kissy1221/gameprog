using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using Const;

public class Character : Object
{

    protected CommandList commandList;
    public CharacterState State = new CharacterState();

    public bool CommandAllow; //�Q�[���}�l�[�W������R�}���h���s�������ꂽ��

    public enum CommandState
    {
        START,
        WAIT,
        EXCUTE,
        FINISH
    }

    public CommandState commandStatus;

    public Vector2Int beforePos; //�ȑO�̃R�}���h�̂Ƃ��ɂ����|�W�V����


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

        //�\���`�F�b�N
        if (commandList.checkSynax())
        {
            while (commandList.Count > 0)
            {
                CommandAllow = false;
                commandStatus = CommandState.START;
                BattleManager.Instance.List.Add(commandList.getFrom(0));
                beforePos = this.gameObject.getMapPosition();//�R�}���h���s�O�Ƀ|�W�V�����̗������L�^
                await UniTask.WaitUntil(() => CommandAllow);
            }
        }

        beforePos = this.gameObject.getMapPosition();


    }
    public async UniTask ExcuteCommandAsync()
    {
        commandStatus = CommandState.EXCUTE;

        //CommandAllow = false;
        Command com = commandList.getFrom(0);//�擪���Q��
        commandList.removeHead();//�擪���O��
        Debug.Log(this.gameObject.name + "=>" + com.date.name + "�����s�I");
        await com.excute(); //�R�}���h���I������܂ő҂�

        if (commandList.Count > 0)
            commandStatus = CommandState.WAIT;
        else
            commandStatus = CommandState.FINISH;



    }


    //����̍s����҂����ɃR�}���h�����s
    //�o�O���� �g��Ȃ�����
    public async void runSelf()
    {
        commandStatus = CommandState.START;

        while (commandList.Count > 0)
        {
            await ExcuteCommandAsync();
        }

        //�R�}���h���I���������Ƃ��L��
        commandStatus = CommandState.FINISH;
    }



}
