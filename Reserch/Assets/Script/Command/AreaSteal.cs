using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaSteal : Command
{
    private int AreaStealCol;

    public AreaSteal(Character character) : base(character)
    {
        Image = Resources.Load<Sprite>("Images/Cube");
    }

    public override void excute()
    {
        Floor[,] m=map.getMap();
        bool flag = false;

        Debug.Log("AREASTEAL");

        for(int i=0;i<m.GetLength(0);i++)
        {
            for(int j=0;j<m.GetLength(1);j++)
            {
                if(m[i,j].getColor()==Floor.floorColor.Blue)
                {
                    AreaStealCol = i;
                    flag = true;
                    break;
                }
            }

            if (flag)
                break;
        }


        for(int i=0;i<m.GetLength(1);i++)
        {
            if(m[AreaStealCol, i].getGameObjectOnFloor() is null)
                m[AreaStealCol, i].changeColor(Floor.floorColor.Red);
        }

        

        CharacterScript.finishMoveReqToManager();
    }
}
