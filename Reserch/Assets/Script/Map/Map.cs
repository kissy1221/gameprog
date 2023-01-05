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

        Debug.Log("MAP START FINISH");

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
        return map[x, y];
    }

    //床を配列として落とし込む
    void initMap1()
    {
        GameObject[] gameObjectMap = GameObject.FindGameObjectsWithTag("Floor");//Floorタグを配列として取得

        int i = 0, j = 0, k = 0, l = 0;

        foreach (GameObject g in gameObjectMap)
        {
            Transform t = g.GetComponent<Transform>();
            Vector3 Pos = t.transform.localPosition;

            switch (Pos.y)
            {

                case 1.14f:
                    map[i, 0] = g.GetComponent<Floor>();
                    i++;
                    break;
                case 0.38f:
                    map[j, 1] = g.GetComponent<Floor>();
                    j++;
                    break;
                case -0.38f:
                    map[k, 2] = g.GetComponent<Floor>();
                    k++;
                    break;
                case -1.14f:
                    map[l, 3] = g.GetComponent<Floor>();
                    l++;
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

}
