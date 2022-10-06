using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private float speed = 5;
    private float distanceX=1.6f;
    private float distanceY = 0.95f;//�ړ�����


    private Vector2 direction;  //�ړ�����
    protected Vector3 targetPos; //�ړ��ړI�n

    public bool movement = false;//�A�N�V�����i�ړ��E�U���j����
    public CommandList2 commandList=new CommandList2();

    public string charTag=null;

    protected void Start()
    {
        targetPos = transform.position;

        
    }

    protected void Update()
    {
        if (!isAction() && GameManager.instance.isRunning())
        {
            if(!GameManager.instance.getMove(charTag))
                run();
            
        }

        move();
    }

    protected void move()
    {

        if(direction!=Vector2.zero&&transform.position==targetPos)
        {
            targetPos += new Vector3(direction.x * distanceX, direction.y * distanceY, 0);
            
        }
        if(transform.position!=targetPos)
            MoveTo(targetPos);

        direction = Vector2.zero;


    }

    private void MoveTo(Vector3 targetPosition)
    {

        //movement = true;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);


        if (transform.position == targetPosition)
        {
            finishMoveReqToManager();
            movement = false;
        }

    }

    public bool isAction()
    {
        return movement;
    }

    public void left()
    {
        direction.x = -1;
    }

    public void right()
    {
        direction.x = 1;
    }

    public void up()
    {
        direction.y = 1;
    }

    public void down()
    {
        direction.y = -1;
    }
    
    public void finishReqToManager(string charTag)
    {
        GameManager.instance.setFinishReq(charTag, true);
    }

    //�Q�[���}�l�[�W���[�ɂP�̃R�}���h���I����`����
    public void finishMoveReqToManager()
    {
        Debug.Log(charTag + "���R�}���h�I�����N�𑗂�܂���");
        GameManager.instance.setMoveReq(charTag,true);
    }


    public void run()
    {
        if(commandList.Count>0)
        {
            Command com = commandList.getFrom(0);//�擪�����o��
            GameManager.instance.setMoveReq(charTag, false);
            com.excute();
            commandList.removeHead();
        }

        if(commandList.Count<=0 && isAction()==false)
        {
            finishReqToManager(charTag);
        }
    }
}
