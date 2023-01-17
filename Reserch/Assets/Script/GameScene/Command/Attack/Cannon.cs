using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using Const;

public class Cannon : Command
{
    int Power = 30;
    GameObject FireEffect;

    public Cannon(GameObject characterObj) : base(characterObj)
    {
        date = Resources.Load(CO.PATH.COMMAND_PLAYER + "Canon") as CommandDate;
        FireEffect = Resources.Load(Const.CO.PATH.PREFAB + "Fire_mag") as GameObject;
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
                AttackObj.GetComponent<Object>().Damage(date.atk);
                break;
            }
            else
            {
                Debug.Log("オブジェクトがありません");
            }
        }

        //CharacterScript.finishMoveReqToManager();
        GameObject obj= Object.Instantiate(FireEffect, CharacterObject.transform.position, Quaternion.identity);
        await UniTask.Delay((int)(0.8 * 1000));
        GameObject.Destroy(obj);
    }

}
