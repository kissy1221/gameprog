using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using Const;

public class Mine : Command
{

    GameObject MinePrefab;

    public Mine(GameObject characterObj) : base(characterObj)
    {
        date = Resources.Load(CO.PATH.COMMAND_PLAYER + "Mine") as CommandDate;

        MinePrefab = (GameObject)Resources.Load("MinePrefab");
    }

    public override async UniTask excute()
    {
        GameObject MineObj;

        Vector2Int putMinePos = CharacterScript.gameObject.getMapPosition() + new Vector2Int(1, 0);
        Vector3 characterPos = CharacterScript.gameObject.transform.position;
        Vector3 putMineV3Pos = characterPos + new Vector3(CO.FLOOR_DISTANCE.X, -0.3f, -1);


        if (map[putMinePos.x, putMinePos.y].getGameObjectOnFloorSub() is null && map[putMinePos.x, putMinePos.y].getGameObjectOnFloor() is null)
        {
            MineObj = Object.Instantiate(MinePrefab, putMineV3Pos, Quaternion.identity);

            MineObj.name = "Mine";
            MineObj.transform.parent = GameObject.FindGameObjectWithTag("Map").transform;

            map[putMinePos.x, putMinePos.y].setSubObject(MineObj);



        }

        await UniTask.Delay((int)(CO.COMMAND_WAIT_TIME * 1000));
        //CharacterScript.finishMoveReqToManager();
    }
}
