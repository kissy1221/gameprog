using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Const;

public class Map : SingletonMonoBehaviour<Map>
{
    private Floor[,] map = new Floor[CO.MAP_SIZE.X, CO.MAP_SIZE.Y];
 
    public Floor[,] getMap()
    {
        return map;
    }


    // Start is called before the first frame update
    void Start()
    {

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");


        initMap1();

        map[CO.INIT_POS.PLAYER.X, CO.INIT_POS.PLAYER.Y].GetComponent<Floor>().putObject(player);
        //map[CO.INIT_POS.ENEMY1.X, CO.INIT_POS.ENEMY1.Y].GetComponent<Floor>().putObject(enemies[0]);

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            printMapOnObject();
        }

    }

    public Floor getFloor(int x,int y)
    {
        try
        {
            return map[x, y];
        }
        catch(System.IndexOutOfRangeException e)
        {
            Debug.LogError("マップ外を参照しています.");
            return null;
        }
        catch (System.Exception e)
        {
            Debug.LogError(e.Message);
            return null;
        }
        
    }

    //床を配列として落とし込む
    void initMap1()
    {
        GameObject[] gameObjectMap = GameObject.FindGameObjectsWithTag("Floor");//Floorタグを配列として取得

        foreach (GameObject g in gameObjectMap)
        {
            Transform t = g.GetComponent<Transform>();
            Vector3 Pos = t.transform.localPosition;

            int insert_y=0;
            int insert_x=0;

            switch (Pos.y)
            {

                case 1.14f:
                    insert_y = 0;
                    break;
                case 0.38f:
                    insert_y = 1;
                    break;
                case -0.38f:
                    insert_y = 2;
                    break;
                case -1.14f:
                    insert_y = 3;
                    break;
            }

            if(g.GetComponent<Floor>().getColor()==Floor.floorColor.Red)
            {
                switch (Pos.x)
                {
                    case -1.95f:
                        insert_x =0;
                        break;
                    case -0.65f:
                        insert_x =1;
                        break;
                    case 0.65f:
                        insert_x =2;
                        break;
                    case 1.95f:
                        insert_x =3;
                        break;
                }
            }
            else
            {
                switch (Pos.x)
                {
                    case -1.95f:
                        insert_x =4;
                        break;
                    case -0.65f:
                        insert_x =5;
                        break;
                    case 0.65f:
                        insert_x =6;
                        break;
                    case 1.95f:
                        insert_x =7;
                        break;
                }
            }

            g.GetComponent<Floor>().mapNo_x = insert_x;
            g.GetComponent<Floor>().mapNo_y = insert_y;
            map[insert_x, insert_y] = g.GetComponent<Floor>();

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

}
