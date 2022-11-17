using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using Const;

public class Sword : Command
{

    int Power = 100;

    public Sword(GameObject characterObj) : base(characterObj)
    {

        name = "Sword";
        Image = Resources.Load<Sprite>("Images/Sword");
    }

    public override async UniTask excute()
    {
        Vector2Int characterPos = CharacterObject.getMapPosition();
        int x = characterPos.x+1;
        int y = characterPos.y;


        if(map[x,y].getGameObjectOnFloor() != null)
        {
            map[x, y].getGameObjectOnFloor().GetComponent<Object>().Damage(Power);
        }
        else
        {
            Debug.Log("オブジェクトがありません");
        }

        //CharacterScript.finishMoveReqToManager();
        await UniTask.Delay((int)(CO.COMMAND_WAIT_TIME * 1000));

    }
}
