using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{

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

        initMap();

        Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        Enemy enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>();

        map1[1, 1].putObjectOnFloor(player);
        map1[4, 1].putObjectOnFloor(enemy);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Player位置:"+searchMap(PLAYER));
        //Debug.Log("Enemy位置:" + searchMap(ENEMY));


        printMapFloorColor();

        printMapOnObject();

    }

    public void putObject(Object obj,Vector2Int pos)
    {
        map1[pos.x, pos.y].putObjectOnFloor(obj);
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


    public void move(Object targetObj,Vector2Int direction)
    {
        Vector2Int targetObjPos = searchMap(targetObj);
        int x = targetObjPos.x;
        int y = targetObjPos.y;

        map1[x, y].putObjectOnFloor(null);
        map1[x + direction.x, y + direction.y].putObjectOnFloor(targetObj);
    }

    //対象物が移動方向に移動できるか
    public bool canMove(Object targetObj,Vector2Int direction)
    {
        Vector2Int targetObjPos = searchMap(targetObj);
        Vector2Int targetPos = targetObjPos + direction;//移動先

        //範囲外ではないか？
        if ((0 <= targetPos.x && targetPos.x < 6) && (0 <= targetPos.y && targetPos.y <= 2))
        {
            Square targetSquare = map1[targetPos.x, targetObjPos.y];//移動先のマス

            //プレイヤーの場合
            if(targetObj.GetType()==typeof(Player))
            {
                if (targetSquare.getFloorColor().GetType() == typeof(Red))
                    return true;
            }
            else
            {
                if (targetSquare.getFloorColor().GetType() == typeof(Blue))
                    return true;
            }
        }

        return false;

    }

   

    //対象物の座標を探す(1つ存在するものに限る)
    public Vector2Int searchMap(Object obj)
    {
        Vector2Int objPos;
        for (int x = 0; x < map1.GetLength(0); x++)
        {
            for (int y = 0; y < map1.GetLength(1); y++)
            {
                if (map1[x, y].getObjectOnFloor() ==obj)
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

        Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (canMove(player, new Vector2Int(0, -1)))
            {
                move(player, new Vector2Int(0, -1));
            }
            else
                Debug.Log("動けません");
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (canMove(player, new Vector2Int(-1, 0)))
            {
                move(player, new Vector2Int(-1, 0));
            }
            else
                Debug.Log("動けません");
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (canMove(player, new Vector2Int(0, 1)))
            {
                move(player, new Vector2Int(0, 1));
            }
            else
                Debug.Log("動けません");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (canMove(player, new Vector2Int(1, 0)))
            {
                move(player, new Vector2Int(1, 0));
            }
            else
                Debug.Log("動けません");
        }
    }
}
