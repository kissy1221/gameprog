using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameObjectExtensions
{
    //ç¿ïWíTçı
    public static Vector2Int getMapPosition(this GameObject self)
    {
        Floor[,] map = GameObject.FindGameObjectWithTag("Map").GetComponent<Map>().getMap();

        //Debug.Log("self:" + self.name);

        for (int x = 0; x < map.GetLength(0); x++)
        {
            for (int y = 0; y < map.GetLength(1); y++)
            {
                Floor floor = map[x, y];

                if (self == floor.getGameObjectOnFloor())
                    return new Vector2Int(x, y);
                        
            }
        }
        return new Vector2Int(-1, -1);
    }

    public static void DestroyfromMap(this GameObject self)
    {
        Floor[,] map = GameObject.FindGameObjectWithTag("Map").GetComponent<Map>().getMap();
        Vector2Int pos = getMapPosition(self);

        map[pos.x, pos.y].setObject(null);

    }
}
