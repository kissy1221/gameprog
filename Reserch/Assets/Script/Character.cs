using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private float speed = 5;
    private float distanceX=1.6f;
    private float distanceY = 0.95f;//移動距離


    private Vector2 direction;  //移動方向
    protected Vector3 targetPos; //移動目的地

    public bool movement = false;//アクション（移動・攻撃）中か
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

    //ゲームマネージャーに１つのコマンドが終了を伝える
    public void finishMoveReqToManager()
    {
        Debug.Log(charTag + "がコマンド終了リクを送りました");
        GameManager.instance.setMoveReq(charTag,true);
    }


    public void run()
    {
        if(commandList.Count>0)
        {
            Command com = commandList.getFrom(0);//先頭を取り出す
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
