using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    const int BLANK = 0;
    const int PLAYER = 1;//プレイヤー
    const int ENEMY = 2;//敵
    const int BLOCK = 3;

    int[,] map = new int[6, 3];

    private Square[,] map1 = new Square[6, 3];

    void initMap()
    {
        for(int i=0;i<map1.GetLength(1); i++)
        {
            for(int j=0; j<map1.GetLength(0); j++)
            {
                if(0<=j && j<3)
                {
                    map1[j, i] = new Square(new Red(), null);
                }
                else
                {
                    map1[j, i] = new Square(new Blue(), null);
                }
            }
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        //map[(int)initPlayerPos.x, (int)initPlayerPos.y] = player;
        //map[(int)initEnemyPos.x, (int)initEnemyPos.y] = enemy;

        initMap();

        Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        Enemy enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>();

        map1[1, 1].putObjectOnFloor(player);
        map1[4, 1].putObjectOnFloor(enemy);

        map[1, 1] = PLAYER;
        map[4,1] = ENEMY;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Player位置:"+searchMap(PLAYER));
        //Debug.Log("Enemy位置:" + searchMap(ENEMY));

        

        printMapFloorColor();

        printMapOnObject();

    }

    //map全体の色
    void printMapFloorColor()
    {
        string print_array = "\n";
        for (int i = 0; i < map1.GetLength(1); i++)
        {
            for (int j = 0; j < map1.GetLength(0); j++)
            {
                print_array += map1[j, i].getFloorColor().GetType().Name + ":";
            }
            print_array += "\n";
        }
        Debug.Log(print_array);
    }

    void printMapOnObject()
    {
        string print_array = "\n";
        for (int i = 0; i < map1.GetLength(1); i++)
        {
            for (int j = 0; j < map1.GetLength(0); j++)
            {
                Object obj = map1[j, i].getObjectOnFloor();
                if (obj==null)
                {
                    print_array += string.Format("{0,11}", "null")+":";
                }
                else
                {
                    print_array += string.Format("{0,8}", map1[j, i].getObjectOnFloor().GetType().Name)+":";
                }
            }
            print_array += "\n";
        }
        Debug.Log(print_array);
    }


    //マップ状態を表示
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

    //マップ内の内部処理 (移動オブジェクト、移動方向)
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

    //移動できるか (対象オブジェクト 移動先)
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
