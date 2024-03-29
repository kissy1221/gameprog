using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using Const;

public class putCube : Command
{
    GameObject CubeObjPrefab;
    GameObject CubeObj;



    public putCube(GameObject characterObj) :base(characterObj)
    {
        date = Resources.Load(CO.PATH.COMMAND_PLAYER + "Cube") as CommandDate;

        CubeObjPrefab = (GameObject)Resources.Load("CubePrefab");

    }

    public override async UniTask excute()
    {

        //Floor[,] map = GameObject.FindGameObjectWithTag("Map").GetComponent<Map>().getMap();
        Vector2Int putCubePos = CharacterScript.gameObject.getMapPosition() + new Vector2Int(1, 0);
        Vector3 characterPos = CharacterScript.gameObject.transform.position;
        Vector3 putCubeV3Pos = characterPos + new Vector3(CO.FLOOR_DISTANCE.X, 0, -1);


        if (map[putCubePos.x, putCubePos.y].getGameObjectOnFloor() is null)
        {
            CubeObj = Object.Instantiate(CubeObjPrefab, putCubeV3Pos, Quaternion.identity);

            CubeObj.name = "Cube";
            CubeObj.transform.parent = GameObject.FindGameObjectWithTag("Map").transform;

            map[putCubePos.x, putCubePos.y].setObject(CubeObj);

            

        }

        await UniTask.Delay((int)(CO.COMMAND_WAIT_TIME * 1000));
        //CharacterScript.finishMoveReqToManager();

        
    }


}
