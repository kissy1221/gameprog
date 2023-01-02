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

            await ExcuteCommandAsync();

        }
        finishMoveReqToManager(); //���삪�I����GM�ɓ`����

        //�S�R�}���h���I��������
        if (commandList.Count <= 0)
        {
            //�R�}���h�I����gamemanager�ɓ`����
            finishReqToManager();
        }
    }
    async UniTask ExcuteCommandAsync()
    {
        CommandAllow = false;
        Command com = commandList.getFrom(0);//�擪���Q��
        GameManager.instance.setMoveReq(this.gameObject, false);
        await com.excute(); //�R�}���h���I������܂ő҂� await�L��

        commandList.removeHead();//�擪���O��
    }
}
