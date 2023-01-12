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

        date = Resources.Load(CO.PATH.COMMAND_PLAYER + "Sword") as CommandDate;

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
            Debug.Log("�I�u�W�F�N�g������܂���");
        }

        //CharacterScript.finishMoveReqToManager();
        await UniTask.Delay((int)(CO.COMMAND_WAIT_TIME * 1000));

    }
}
