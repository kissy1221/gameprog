using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaSteal : Command
{
    private int AreaStealCol;
    Floor[,] m;

    public AreaSteal(GameObject characterObj) : base(characterObj)
    {
        Image = Resources.Load<Sprite>("Images/Cube");
        m = GameObject.FindGameObjectWithTag("Map").GetComponent<Map>().getMap();
    }

    public override void excute()
    {

        AreaStealCol = searchAreaStealCol();


        for(int i=0;i<m.GetLength(1);i++)
        {
            if(m[AreaStealCol, i].getGameObjectOnFloor() is null)
                m[AreaStealCol, i].changeColor(Floor.floorColor.Red);
        }

        

        CharacterScript.finishMoveReqToManager();
    }

    private int searchAreaStealCol()
    {
        for (int i = 0; i < m.GetLength(0); i++)
        {
            for (int j = 0; j < m.GetLength(1); j++)
            {
                if (m[i, j].getColor() == Floor.floorColor.Blue)
                {
                    return i;
                }
            }
        }

        return -1;

    }
}
