using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;
using Const;

public class Character : Object
{

    protected CommandList commandList; //���g�̏������Ă���R�}���h���X�g
    protected List<Condition> status = new List<Condition>();
    public CharacterState State = new CharacterState();

    Image conditionImage;

    [HideInInspector] public Vector2Int beforePos; //�ȑO�̃R�}���h�̂Ƃ��ɂ����|�W�V����



    

    public enum CommandState
    {
        START,
        WAIT,
        EXCUTE,
        FINISH
    }

    public CommandState commandStatus;


    protected override void Start()
    {
        base.Start();

        commandList = GetComponent<CommandList>();
    }

    protected override void Update()
    {
        base.Update();

        if (GameManager.instance.State != GameManager.gameState.Run)
            commandStatus = CommandState.START;

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
                if (commandList.Count>0)
                {
                    commandStatus = CommandState.WAIT; //�ҋ@
                    //Debug.Log($"{name}=>�R�}���h������̂őҋ@���܂�");
                    await UniTask.WaitUntil(() => BattleManager.Instance.state==BattleManager.BattleManagerState.WAIT); //�o�g���}�l�[�W���[�����s�I������܂őҋ@
                }
                
            }
        }

        //�R�}���h���I���������Ƃ��L��
        commandStatus = CommandState.FINISH;
        Debug.Log($"{name}=>�R�}���h�I���I");
        beforePos = this.gameObject.getMapPosition();

    }

    public void sendCommandtoBattleManager()
    {
        Command com = commandList.getFrom(0);//�擪���Q��
        Debug.Log($"{name }=>{com.date.name}��n���܂�");
        commandList.removeHead();//�擪���O��
        BattleManager.Instance.List.Add(com);//�n��
        
    }

    protected override void Death()
    {
        base.Death();
        commandList.clear();
    }

    //
    void showCondition()
    {
        
    }



}
