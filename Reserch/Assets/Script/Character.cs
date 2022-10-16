using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : Object
{
    private float speed = 5;
    private float distanceX=1.6f;
    private float distanceY = 0.95f;//�ړ�����


    private Vector2 direction;  //�ړ�����
    protected Vector3 targetPos; //�ړ��ړI�n

    public bool movement = false;//�A�N�V�����i�ړ��E�U���j����
    public CommandList2 commandList=new CommandList2();

    public string charTag=null;

    public enum PlayerState
    {
        WAIT,
        MOVE,
        ATTACK
    };

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
        Floor[,] map = GameObject.FindGameObjectWithTag("Map").GetComponent<Map>().getMap();
        Vector2Int CharacterPos = this.gameObject.getMapPosition();
        int x = CharacterPos.x;
        int y = CharacterPos.y;

        map[x, y].GetComponent<Floor>().setObject(null);
        map[x-1, y].GetComponent<Floor>().setObject(this.gameObject);

        direction.x = -1;
    }

    public void right()
    {
        Floor[,] map = GameObject.FindGameObjectWithTag("Map").GetComponent<Map>().getMap();
        Vector2Int CharacterPos = this.gameObject.getMapPosition();
        int x = CharacterPos.x;
        int y = CharacterPos.y;

        map[x, y].GetComponent<Floor>().setObject(null);
        map[x+1, y].GetComponent<Floor>().setObject(this.gameObject);
        Debug.Log("�z�u����");


        direction.x = 1;
    }

    public void up()
    {
        Floor[,] map = GameObject.FindGameObjectWithTag("Map").GetComponent<Map>().getMap();
        Vector2Int CharacterPos = this.gameObject.getMapPosition();
        int x = CharacterPos.x;
        int y = CharacterPos.y;

        map[x, y].GetComponent<Floor>().setObject(null);
        map[x, y-1].GetComponent<Floor>().setObject(this.gameObject);
        Debug.Log("�z�u����");

        direction.y = 1;
    }

    public void down()
    {

        Floor[,] map = GameObject.FindGameObjectWithTag("Map").GetComponent<Map>().getMap();
        Vector2Int CharacterPos = this.gameObject.getMapPosition();
        int x = CharacterPos.x;
        int y = CharacterPos.y;

        map[x, y].GetComponent<Floor>().setObject(null);
        map[x, y+1].GetComponent<Floor>().setObject(this.gameObject);
        Debug.Log("�z�u����");

        direction.y = -1;
    }
    
    public void finishReqToManager()
    {

        GameManager.instance.setFinishReq(this, true);
    }

    //�Q�[���}�l�[�W���[�ɂP�̃R�}���h���I����`����
    public void finishMoveReqToManager()
    {
        GameManager.instance.setMoveReq(this,true);
    }


    public void run()
    {
        if(commandList.Count>0)
        {
            Command com = commandList.getFrom(0);//�擪�����o��
            GameManager.instance.setMoveReq(this, false);
            com.excute();
            commandList.removeHead();
        }

        if(commandList.Count<=0 && isAction()==false)
        {
            finishReqToManager();
        }
    }

    public bool canMove(Vector2Int direction)
    {
        Vector2Int CharacterPos = this.gameObject.getMapPosition();
        Floor[,] map = GameObject.FindGameObjectWithTag("Map").GetComponent<Map>().getMap();
        Vector2Int targetPos = CharacterPos + direction;

        //�͈͊O���H�ړ���͈ړ��\��
        if ((0 <= targetPos.x && targetPos.x < 6) && (0 <= targetPos.y && targetPos.y <= 2))
        {
            Floor targetFloor = map[targetPos.x, targetPos.y];

            if(this.gameObject.tag=="Player")
            {
                if ((targetFloor.getColor() == Floor.floorColor.Red)&&!(targetFloor.getGameObjectOnFloor() is null))
                {
                    return true;
                }
                    
            }
            else
            {
                if ((targetFloor.getColor() == Floor.floorColor.Blue)&&!(targetFloor.getGameObjectOnFloor() is null))
                    return true;
            }
        }

        return false;
    }
}
