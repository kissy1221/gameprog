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
        Floor[,] map = GameObject.FindGameObjectWithTag("Map").GetComponent<Map>().getMap();
        Vector2Int putCubePos = CharacterScript.gameObject.getMapPosition() + new Vector2Int(1, 0);

        Debug.Log("�L���[�u�z�u���W:" + putCubePos);


        

        Debug.Log("�L���[�u�z�u����");
        
    }
}
