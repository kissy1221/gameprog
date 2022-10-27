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
            //StartCoroutine(ExcuteCommand());
            await ExcuteCommand();
        }
    }

    private async UniTask ExcuteCommand()
    {

        Command com = commandList.getFrom(0);//�擪�����o��
        GameManager.instance.setMoveReq(this.gameObject, false);
        com.excute();
        commandList.removeHead();
        CommandAllow = false;

        //yield return new WaitForSeconds(Const.CO.COMMAND_WAIT_TIME);
        await UniTask.Delay(500);

        Debug.Log("moveFinish!");

        finishMoveReqToManager();

        if(commandList.Count<=0)
        {
            finishReqToManager();
        }

    }
}
