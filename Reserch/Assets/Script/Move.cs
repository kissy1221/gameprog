using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Const;

public class Move : MonoBehaviour
{

    private float speed = 5;
    private float distanceX = 1.3f;
    private float distanceY = 0.76f;//移動距離


    private Vector2 direction;  //移動方向
    protected Vector3 targetPos; //移動目的地

    Character character;

    CharacterState state;

    Floor[,] map; //マップ
    // Start is called before the first frame update
    void Start()
    {
        targetPos = transform.position;
        map = GameObject.FindGameObjectWithTag("Map").GetComponent<Map>().getMap();
        state = gameObject.GetComponent<Character>().State;
        character = gameObject.GetComponent<Character>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M) && this.gameObject.tag==("Player"))
        {
            moveAt(2, 0);
        }
        move();
    }

    protected void move()
    {

        if (direction != Vector2.zero && transform.position == targetPos)
        {
            targetPos += new Vector3(direction.x * distanceX, direction.y * distanceY, 0);

        }
        if (transform.position != targetPos)
            MoveTo(targetPos);

        direction = Vector2.zero;


    }

    private void MoveTo(Vector3 targetPosition)
    {

        //movement = true;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);


        if (transform.position == targetPosition)
        {
            //character.finishMoveReqToManager();
            character.State.setState(CharacterState.State.WAIT);
        }

    }

    public bool canMove(Vector2Int direction)
    {
        Vector2Int CharacterPos = this.gameObject.getMapPosition();
        //Floor[,] map = GameObject.FindGameObjectWithTag("Map").GetComponent<Map>().getMap();
        Vector2Int targetPos = CharacterPos + direction;

        //範囲外か？移動先は移動可能か
        if ((0 <= targetPos.x && targetPos.x < CO.MAP_SIZE.X) && (0 <= targetPos.y && targetPos.y < CO.MAP_SIZE.Y))
        {
            Floor targetFloor = map[targetPos.x, targetPos.y];

            if (this.gameObject.tag == "Player")
            {
                if ((targetFloor.getColor() == Floor.floorColor.Red) && (targetFloor.getGameObjectOnFloor() is null))
                {
                    return true;
                }

            }
            else
            {
                if ((targetFloor.getColor() == Floor.floorColor.Blue) && (targetFloor.getGameObjectOnFloor() is null))
                    return true;
            }
        }

        return false;
    }

    public void left()
    {

        //Floor[,] map = GameObject.FindGameObjectWithTag("Map").GetComponent<Map>().getMap();
        Vector2Int CharacterPos = this.gameObject.getMapPosition();
        int x = CharacterPos.x;
        int y = CharacterPos.y;

        map[x, y].GetComponent<Floor>().setObject(null);
        map[x - 1, y].GetComponent<Floor>().setObject(this.gameObject);

        state.setState(CharacterState.State.MOVE);

        direction.x = -1;
    }

    public void right()
    {
        //Floor[,] map = GameObject.FindGameObjectWithTag("Map").GetComponent<Map>().getMap();
        Vector2Int CharacterPos = this.gameObject.getMapPosition();
        int x = CharacterPos.x;
        int y = CharacterPos.y;

        map[x, y].GetComponent<Floor>().setObject(null);
        map[x + 1, y].GetComponent<Floor>().setObject(this.gameObject);

        state.setState(CharacterState.State.MOVE);


        direction.x = 1;
    }

    public void up()
    {
        //Floor[,] map = GameObject.FindGameObjectWithTag("Map").GetComponent<Map>().getMap();
        Vector2Int CharacterPos = this.gameObject.getMapPosition();
        int x = CharacterPos.x;
        int y = CharacterPos.y;

        map[x, y].GetComponent<Floor>().setObject(null);
        map[x, y - 1].GetComponent<Floor>().setObject(this.gameObject);

        state.setState(CharacterState.State.MOVE);

        direction.y = 1;
    }

    public void down()
    {

        //Floor[,] map = GameObject.FindGameObjectWithTag("Map").GetComponent<Map>().getMap();
        Vector2Int CharacterPos = this.gameObject.getMapPosition();
        int x = CharacterPos.x;
        int y = CharacterPos.y;

        map[x, y].GetComponent<Floor>().setObject(null);
        map[x, y + 1].GetComponent<Floor>().setObject(this.gameObject);

        state.setState(CharacterState.State.MOVE);

        direction.y = -1;
    }

    //map座標の場所へ移動 (unityのグローバル座標指定ではない)
    public void moveAt(int x, int y)
    {
        Vector2Int CharacterPos = this.gameObject.getMapPosition();
        map[CharacterPos.x, CharacterPos.y].GetComponent<Floor>().setObject(null);
        map[x, y].GetComponent<Floor>().setObject(this.gameObject);

        targetPos = map[x, y].PlayerFloorPos;
        this.transform.position = map[x,y].PlayerFloorPos;

    }


}
