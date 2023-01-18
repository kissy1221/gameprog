using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using Const;

public class Mine : Command
{

    GameObject MinePrefab;
    Vector2Int putPos;

    public Mine(GameObject characterObj) : base(characterObj)
    {
        date = Resources.Load(CO.PATH.COMMAND_PLAYER + "Mine") as CommandDate;

        MinePrefab = (GameObject)Resources.Load("MinePrefab");
    }

    public Mine(GameObject characterObj,Vector2Int putPos):base(characterObj)
    {
        date = Resources.Load(CO.PATH.COMMAND_PLAYER + "Mine") as CommandDate;

        MinePrefab = (GameObject)Resources.Load("MinePrefab");
        this.putPos = putPos;
    }

    public override async UniTask excute()
    {
        GameObject MineObj;
        Vector3 putMineV3Pos;
        Vector2Int putMinePos;

        if (CharacterObject.tag=="Player")
        {
            putMinePos = CharacterScript.gameObject.getMapPosition() + new Vector2Int(1, 0);
            Floor f = Map.Instance.getMap()[putMinePos.x, putMinePos.y];
            putMineV3Pos = new Vector3(f.PlayerFloorPos.x+0.1f, f.PlayerFloorPos.y-0.55f, 0);
            /*
            Vector3 characterPos = CharacterScript.gameObject.transform.position;
            putMineV3Pos = characterPos + new Vector3(CO.FLOOR_DISTANCE.X, -0.3f, -1);
            */
        }
        else
        {
            putMinePos = putPos;
            Floor f = Map.Instance.getMap()[putMinePos.x, putMinePos.y];
            putMineV3Pos = new Vector3(f.PlayerFloorPos.x + 0.1f, f.PlayerFloorPos.y - 0.55f, 0);
        }

        if (map[putMinePos.x, putMinePos.y].getGameObjectOnFloorSub() is null && map[putMinePos.x, putMinePos.y].getGameObjectOnFloor() is null)
        {
            MineObj = Object.Instantiate(MinePrefab, putMineV3Pos, Quaternion.identity);
            map[putMinePos.x, putMinePos.y].setSubObject(MineObj);

        }

        await UniTask.Delay((int)(CO.COMMAND_WAIT_TIME * 1000));
    }
}
