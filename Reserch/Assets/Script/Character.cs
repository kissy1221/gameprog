using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : Object
{

    public CommandList2 commandList=new CommandList2();

    public CharacterState State = new CharacterState();

    bool flag = false;

    int i=1;

    public bool CommandAllow = true; //�Q�[���}�l�[�W������R�}���h���s�������ꂽ��

    protected void Start()
    {
        base.Start();
    }

    protected void Update()
    {
        base.Update();

        //Debug.Log(this.gameObject.tag + ":" + CommandAllow);

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


    public void run()
    {
        if(commandList.Count>0)
        {
            /*
            Command com = commandList.getFrom(0);//�擪�����o��
            GameManager.instance.setMoveReq(this.gameObject, false);
            com.excute();
            commandList.removeHead();
            */
            StartCoroutine(ExcuteCommand());
        }

        /*
        if(commandList.Count<=0 && State.getState() == CharacterState.State.WAIT)
        {
            if(!flag)
            {
                Debug.Log(this.gameObject.tag + "�̃R�}���h���S�ďI����������j����");
                flag = true;
            }
            
            finishReqToManager();
        }
        */
    }

    private IEnumerator ExcuteCommand()
    {

        Command com = commandList.getFrom(0);//�擪�����o��
        GameManager.instance.setMoveReq(this.gameObject, false);
        com.excute();
        Debug.Log(this.gameObject.tag+":"+i + "��ڎ��s");
        i++;
        commandList.removeHead();
        CommandAllow = false;

        yield return new WaitForSeconds(0.4f);

        finishMoveReqToManager();

        if(commandList.Count<=0)
        {
            finishReqToManager();
        }

    }
}
