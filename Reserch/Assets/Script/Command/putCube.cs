using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class putCube : Command
{
    GameObject CubeObjPrefab;
    GameObject CubeObj;



    public putCube(GameObject characterObj) :base(characterObj)
    {
        Image = Resources.Load<Sprite>("Images/Cube");
        CubeObjPrefab = (GameObject)Resources.Load("CubePrefab");

    }

    public override void excute()
    {

        //Floor[,] map = GameObject.FindGameObjectWithTag("Map").GetComponent<Map>().getMap();
        Vector2Int putCubePos = CharacterScript.gameObject.getMapPosition() + new Vector2Int(1, 0);
        Vector3 characterPos = CharacterScript.gameObject.transform.position;
        Vector3 putCubeV3Pos = characterPos + new Vector3(1.6f, 0, -1);


        if (map[putCubePos.x, putCubePos.y].getGameObjectOnFloor() is null)
        {
            CubeObj = Object.Instantiate(CubeObjPrefab, putCubeV3Pos, Quaternion.identity);

            CubeObj.name = "Cube";
            CubeObj.transform.parent = GameObject.FindGameObjectWithTag("Map").transform;

            map[putCubePos.x, putCubePos.y].setObject(CubeObj);

        }


        CharacterScript.finishMoveReqToManager();

        
    }


}
