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

        //�\���`�F�b�N
        if(commandList.checkSynax())
        {
            while (commandList.Count > 0)
            {
                await UniTask.WaitUntil(() => CommandAllow);
                await ExcuteCommandAsync();
            }
        }

        //�R�}���h���I���������Ƃ��L��
        commandStatus = CommandState.FINISH;


    }
    protected async UniTask ExcuteCommandAsync()
    {
        commandStatus = CommandState.EXCUTE;

        CommandAllow = false;
        Command com = commandList.getFrom(0);//�擪���Q��
        await com.excute(); //�R�}���h���I������܂ő҂�

        commandList.removeHead();//�擪���O��
        commandStatus = CommandState.WAIT;
        

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
