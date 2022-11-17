using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using Const;

public class Character : Object
{

    public CommandList2 commandList=new CommandList2();

    public CharacterState State = new CharacterState();

    public bool CommandAllow = true; //�Q�[���}�l�[�W������R�}���h���s�������ꂽ��

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

    //�Q�[���}�l�[�W���[�ɂP�̃R�}���h���I����`����
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

            //���L���R�}���h����I����̓���

            finishMoveReqToManager(); //���삪�I����GM�ɓ`����

            if (commandList.Count <= 0)
            {
                finishReqToManager();
            }
        }
    }

    private void ExcuteCommand()
    {
        CommandAllow = false;
        Command com = commandList.getFrom(0);//�擪���Q��
        GameManager.instance.setMoveReq(this.gameObject, false);
        com.excute();
        commandList.removeHead();//�擪���O��
        
    }

    async UniTask ExcuteCommandAsync()
    {
        CommandAllow = false;
        Command com = commandList.getFrom(0);//�擪���Q��
        GameManager.instance.setMoveReq(this.gameObject, false);
        com.excute(); //�R�}���h���I������܂ő҂� await�L��

        commandList.removeHead();//�擪���O��

        finishMoveReqToManager(); //���삪�I����GM�ɓ`����

        if (commandList.Count <= 0)
        {
            finishReqToManager();
        }
    }
}
