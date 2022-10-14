using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class putCube : Command
{

    public putCube(Character character):base(character)
    {
        Image = Resources.Load<Sprite>("Images/Cube");
    }

    public override void excute()
    {
        /*
        Vector2Int putCubePos = map.searchMap(CharacterScript) + new Vector2Int(1, 0);

        Debug.Log("キューブ配置座標:" + putCubePos);

        map.putObject(new Cube(), putCubePos);

        Debug.Log("キューブ配置成功");
        */
    }
}
