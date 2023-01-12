using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using Const;

public class AreaSteal : Command
{
    private int AreaStealCol;

    public AreaSteal(GameObject characterObj) : base(characterObj)
    {
        date = Resources.Load(CO.PATH.COMMAND_PLAYER + "AreaSteal") as CommandDate;
    }

    public override async UniTask excute()
    {

        AreaStealCol = searchAreaStealCol();


        for(int i=0;i<map.GetLength(1);i++)
        {
            if(map[AreaStealCol, i].getGameObjectOnFloor() is null)
                map[AreaStealCol, i].changeColor(Floor.floorColor.Red);
        }


        await UniTask.Delay((int)(CO.COMMAND_WAIT_TIME * 1000));
        //CharacterScript.finishMoveReqToManager();
    }

    private int searchAreaStealCol()
    {
        for (int i = 0; i < map.GetLength(0); i++)
        {
            for (int j = 0; j < map.GetLength(1); j++)
            {
                if (map[i, j].getColor() == Floor.floorColor.Blue)
                {
                    return i;
                }
            }
        }

        return -1;

    }
}
