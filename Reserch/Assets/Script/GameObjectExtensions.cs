using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameObjectExtensions
{
    public static Vector2Int getMapPosition(this GameObject self)
    {
        GameObject[,] map = GameObject.FindGameObjectWithTag("Map").GetComponent<Map>().getMap();

        Debug.Log("self:" + self.name);

        for (int x = 0; x < map.GetLength(0); x++)
        {
            for (int y = 0; y < map.GetLength(1); y++)
            {
                Floor floor = map[x, y].GetComponent<Floor>();

                if (self == floor.getGameObjectOnFloor())
                    return new Vector2Int(x, y);
                        
            }
        }
        return new Vector2Int(-1, -1);
    }
}
