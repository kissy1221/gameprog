using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using Const;

public class Character : Object
{

    protected CommandList commandList;
    public CharacterState State = new CharacterState();

    [HideInInspector] public Vector2Int beforePos; //�ȑO�̃R�}���h�̂Ƃ��ɂ����|�W�V����

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

        if (GameManager.instance.State != GameManager.gameState.Run)
            commandStatus = CommandState.START;

        if(Input.GetKeyDown(KeyCode.D))
        {
            this.Damage(10);
        }

    }


    public virtual async UniTask run()
    {
        commandStatus = CommandState.START;
        GameManager.instance.switchRun(true);

        //�\���`�F�b�N
        if(commandList.checkSynax())
        {
            while (commandList.Count > 0)
            {

                beforePos = this.gameObject.getMapPosition();//�R�}���h���s�O�Ƀ|�W�V�����̗������L�^

                sendCommandtoBattleManager();//�R�}���h���o�g���}�l�[�W���[�ɓn��
                await UniTask.WaitUntil(() => BattleManager.Instance.state == BattleManager.BattleManagerState.EXCUTE); //�o�g���}�l�[�W���[�����s����܂őҋ@

                //���̃R�}���h������ꍇ
                if(commandList.Count>0)
                {
                    commandStatus = CommandState.WAIT; //�ҋ@
                    await UniTask.WaitUntil(() => BattleManager.Instance.state==BattleManager.BattleManagerState.WAIT); //�o�g���}�l�[�W���[�����s�I������܂őҋ@
                }
                
            }
        }

        //�R�}���h���I���������Ƃ��L��
        commandStatus = CommandState.FINISH;
        beforePos = this.gameObject.getMapPosition();

    }
    public async UniTask ExcuteCommandAsync()
    {
        
        commandStatus = CommandState.EXCUTE;
        Command com = commandList.getFrom(0);//�擪���Q��
        BattleManager.Instance.List.Add(com);//�n��

        //Debug.Log(this.gameObject.name+"=>"+com.date.name+"�����s�I");
        //await com.excute(); //�R�}���h���I������܂ő҂�

        commandList.removeHead();//�擪���O��

        
        //await UniTask.WaitUntil(() => BattleManager.Instance.flag);
    }

    public void sendCommandtoBattleManager()
    {
        Command com = commandList.getFrom(0);//�擪���Q��
        commandList.removeHead();//�擪���O��
        BattleManager.Instance.List.Add(com);//�n��
        
    }

    public async UniTask waitResponseFromBattleManager()
    {
        bool goSign = false;

        await UniTask.WaitUntil(() => goSign); //true�ɂȂ�܂őҋ@
    }



}
