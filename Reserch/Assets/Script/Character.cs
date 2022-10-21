using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : Object
{

    public CommandList2 commandList=new CommandList2();

    public CharacterState State = new CharacterState();

    protected void Start()
    {
        base.Start();
    }

    protected void Update()
    {
        base.Update();

        if (State.getState()==CharacterState.State.WAIT && GameManager.instance.isRunning())
        {

            if(!GameManager.instance.getMove(this.gameObject))
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


    public void run()
    {
        if(commandList.Count>0)
        {
            Command com = commandList.getFrom(0);//�擪�����o��
            GameManager.instance.setMoveReq(this.gameObject, false);
            com.excute();
            commandList.removeHead();
        }

        if(commandList.Count<=0 && State.getState() == CharacterState.State.WAIT)
        {
            finishReqToManager();
        }
    }

    private IEnumerator ExcuteCommand()
    {

    }
}
