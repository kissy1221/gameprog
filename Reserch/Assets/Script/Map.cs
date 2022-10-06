using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    const int BLANK = 0;
    const int PLAYER = 1;//プレイヤー
    const int ENEMY = 2;//敵
    const int BLOCK = 3;

    Vector2 initPlayerPos = new Vector2(1, 1);
    Vector2 initEnemyPos = new Vector2(4, 1);

    int[,] map = new int[6, 3];



    // Start is called before the first frame update
    void Start()
    {
        //map[(int)initPlayerPos.x, (int)initPlayerPos.y] = player;
        //map[(int)initEnemyPos.x, (int)initEnemyPos.y] = enemy;

        map[1, 1] = PLAYER;
        map[4,1] = ENEMY;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Player位置:"+searchMap(PLAYER));
        Debug.Log("Enemy位置:" + searchMap(ENEMY));


    }

    void printMap()
    {
        string print_array = "\n";
        for (int i = 0; i < map.GetLength(1); i++)
        {
            for (int j = 0; j < map.GetLength(0); j++)
            {
                print_array += map[j, i].ToString() + ":";
            }
            print_array += "\n";
        }
        Debug.Log(print_array);
    }

    public void move(string targetObjTag,Vector2Int direction)
    {
        int targetObj;

        if (targetObjTag == "Player")
        {
            targetObj = 1;
        }
        else
            targetObj = 2;


        //現在のプレイヤー位置を探索
        Vector2Int targetObjPos = searchMap(targetObj);
        int x = targetObjPos.x;
        int y = targetObjPos.y;

        map[x, y] = BLANK;
        map[x + direction.x, y + direction.y] = targetObj; 

    }

    public bool canMove(string targetObjTag, Vector2Int direction)
    {
        int targetObj;

        if (targetObjTag == "Player")
        {
            targetObj = PLAYER;
        }
        else
            targetObj = ENEMY;

        Vector2Int targetObjPos = searchMap(targetObj);
        Vector2Int targetPos = targetObjPos + direction;

        if(targetObj==PLAYER)
        {
            if ((0 <= targetPos.x && targetPos.x <= 2) && (0 <= targetPos.y && targetPos.y <= 2))
            {
                return true;
            }
            return false;
        }
        else
        {
            if ((3 <= targetPos.x && targetPos.x <= 5) && (0 <= targetPos.y && targetPos.y <= 2))
            {
                return true;
            }
            return false;
        }
        
    }

    Vector2Int searchMap(int obj)
    {
        Vector2Int objPos;
        for (int x = 0; x < map.GetLength(0);x++)
        {
            for (int y = 0; y < map.GetLength(1); y ++)
            {
                if(map[x,y]==obj)
                {
                    objPos = new Vector2Int(x, y);
                    return objPos;
                }
            }
        }

        return new Vector2Int(-1, -1);
    }

    void input()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (canMove("Player", new Vector2Int(0, -1)))
            {
                move("Player", new Vector2Int(0, -1));
            }
            else
                Debug.Log("動けません");
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (canMove("Player", new Vector2Int(-1, 0)))
            {
                move("Player", new Vector2Int(-1, 0));
            }
            else
                Debug.Log("動けません");
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (canMove("Player", new Vector2Int(0, 1)))
            {
                move("Player", new Vector2Int(0, 1));
            }
            else
                Debug.Log("動けません");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (canMove("Player", new Vector2Int(1, 0)))
            {
                move("Player", new Vector2Int(1, 0));
            }
            else
                Debug.Log("動けません");
        }
    }
}
