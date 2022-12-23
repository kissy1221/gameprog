using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using Const;

public class AreaSteal : Command
{
    private int AreaStealCol;
    Floor[,] m;

    public AreaSteal(GameObject characterObj) : base(characterObj)
    {
        Image = Resources.Load<Sprite>("Images/Cube");
        m = GameObject.FindGameObjectWithTag("Map").GetComponent<Map>().getMap();
    }

    public override async UniTask excute()
    {

        AreaStealCol = searchAreaStealCol();


        for(int i=0;i<m.GetLength(1);i++)
        {
            if(m[AreaStealCol, i].getGameObjectOnFloor() is null)
                m[AreaStealCol, i].changeColor(Floor.floorColor.Red);
        }


        await UniTask.Delay((int)(CO.COMMAND_WAIT_TIME * 1000));
        //CharacterScript.finishMoveReqToManager();
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
