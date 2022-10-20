using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : Object
{
    private float speed = 5;
    private float distanceX=1.6f;
    private float distanceY = 0.95f;//移動距離


    private Vector2 direction;  //移動方向
    protected Vector3 targetPos; //移動目的地

    public CommandList2 commandList=new CommandList2();

    public CharacterState State = new CharacterState();

    protected void Start()
    {
        targetPos = transform.position;
        
    }

    protected void Update()
    {
        if (State.getState()==CharacterState.State.WAIT && GameManager.instance.isRunning())
        {
            if(!GameManager.instance.getMove(this.gameObject))
                run();
            
        }

        Debug.Log(State.getState());

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
            State.setState(CharacterState.State.WAIT);
        }

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

        direction.y = -1;
    }
    
    public void finishReqToManager()
    {

        GameManager.instance.setFinishReq(this, true);
    }

    //ゲームマネージャーに１つのコマンドが終了を伝える
    public void finishMoveReqToManager()
    {
        GameManager.instance.setMoveReq(this,true);
    }


    public void run()
    {
        if(commandList.Count>0)
        {
            Command com = commandList.getFrom(0);//先頭を取り出す
            GameManager.instance.setMoveReq(this, false);
            com.excute();
            commandList.removeHead();
        }

        if(commandList.Count<=0 && State.getState() == CharacterState.State.WAIT)
        {
            finishReqToManager();
        }
    }

    public bool canMove(Vector2Int direction)
    {
        Vector2Int CharacterPos = this.gameObject.getMapPosition();
        Floor[,] map = GameObject.FindGameObjectWithTag("Map").GetComponent<Map>().getMap();
        Vector2Int targetPos = CharacterPos + direction;

        //範囲外か？移動先は移動可能か
        if ((0 <= targetPos.x && targetPos.x < 6) && (0 <= targetPos.y && targetPos.y <= 2))
        {
            Floor targetFloor = map[targetPos.x, targetPos.y];

            if(this.gameObject.tag=="Player")
            {
                if ((targetFloor.getColor() == Floor.floorColor.Red)&&(targetFloor.getGameObjectOnFloor() is null))
                {
                    return true;
                }
                    
            }
            else
            {
                if ((targetFloor.getColor() == Floor.floorColor.Blue)&&(targetFloor.getGameObjectOnFloor() is null))
                    return true;
            }
        }

        return false;
    }
}
