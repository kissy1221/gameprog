using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using Const;

public class Cannon : Command
{
    int Power = 30;

    public Cannon(GameObject characterObj) : base(characterObj)
    {

        name = "Cannon";
        Image = Resources.Load<Sprite>("Images/Sword");
    }

    public override async UniTask excute()
    {
        Vector2Int characterPos = CharacterObject.getMapPosition();
        int x = characterPos.x + 1;
        int y = characterPos.y;

        for(int i=x;i<map.GetLength(0);i++)
        {
            GameObject AttackObj=map[i,y].getGameObjectOnFloor();
            if(AttackObj!=null)
            {
                AttackObj.GetComponent<Object>().Damage(Power);
                break;
            }
            else
            {
                Debug.Log("オブジェクトがありません");
            }
        }

        //CharacterScript.finishMoveReqToManager();
        await UniTask.Delay((int)(CO.COMMAND_WAIT_TIME * 1000));
    }

}
