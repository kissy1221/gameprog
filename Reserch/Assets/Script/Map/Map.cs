using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{

    private Square[,] map1 = new Square[6, 3];

    //private GameObject[,] map = new GameObject[6, 3];
    private Floor[,] map = new Floor[6, 3];

    public Floor[,] getMap()
    {
        return map;
    }


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

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");

        initMap1();

        map[1, 1].GetComponent<Floor>().setObject(player);
        map[4, 1].GetComponent<Floor>().setObject(enemy);

        map1[1, 1].putObjectOnFloor(player);
        map1[4, 1].putObjectOnFloor(enemy);



    }

    // Update is called once per frame
    void Update()
    {
        printMapOnObject();
        //Debug.Log("Player位置:"+searchMap(PLAYER));
        //Debug.Log("Enemy位置:" + searchMap(ENEMY));

    }

    //床を配列として落とし込む
    void initMap1()
    {
        GameObject[] gameObjectMap = GameObject.FindGameObjectsWithTag("Floor");//Floorタグを配列として取得

        int i = 0, j = 0, k = 0;

        foreach (GameObject g in gameObjectMap)
        {
            Transform t = g.GetComponent<Transform>();
            Vector3 Pos = t.transform.localPosition;

            switch (Pos.y)
            {
                case 0.95f:
                    map[i, 0] = g.GetComponent<Floor>();
                    i++;
                    break;
                case 0:
                    map[j, 1] = g.GetComponent<Floor>();
                    j++;
                    break;
                case -0.95f:
                    map[k, 2] = g.GetComponent<Floor>();
                    k++;
                    break;
            }

        }
    }

    void printMapObj()
    {
        string print_array = "\n";
        for (int i = 0; i < map.GetLength(1); i++)
        {
            for (int j = 0; j < map.GetLength(0); j++)
            {
                Floor f = map[j, i];
                if(f.getColor()==Floor.floorColor.Red)
                {
                    print_array += "赤:";
                }
                else
                {
                    print_array += "青:";
                }
            }
            print_array += "\n";
        }
        Debug.Log(print_array);
    }

    void printMapOnObject()
    {
        string print_array = "\n";
        for (int i = 0; i < map.GetLength(1); i++)
        {
            for (int j = 0; j < map.GetLength(0); j++)
            {
                GameObject obj = map[j, i].getGameObjectOnFloor();
                if (obj==null)
                {
                    print_array += string.Format("{0,11}", "null")+":";
                }
                else
                {
                    print_array += string.Format("{0,8}", obj.name)+":";
                }
            }
            print_array += "\n";
        }
        Debug.Log(print_array);
    }


    public void move(GameObject targetObj,Vector2Int direction)
    {
        Vector2Int targetObjPos = searchMap(targetObj);
        int x = targetObjPos.x;
        int y = targetObjPos.y;

        map1[x, y].putObjectOnFloor(null);
        map1[x + direction.x, y + direction.y].putObjectOnFloor(targetObj);
    }

   

    //対象物の座標を探す(1つ存在するものに限る)
    public Vector2Int searchMap(GameObject obj)
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

    /*
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
    */
}
