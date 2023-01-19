using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using Const;

public class Sword : Command
{

    int Power = 100;
    GameObject Effect;

    public Sword(GameObject characterObj) : base(characterObj)
    {

        date = Resources.Load(CO.PATH.COMMAND_PLAYER + "Sword") as CommandDate;
        Effect = Resources.Load(CO.PATH.PREFAB + "HitEffect_B") as GameObject;
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

        float effect_x=map[x,y].PlayerFloorPos.x;
        float effect_y= map[x, y].PlayerFloorPos.y;
        Vector3 vector = new Vector3(effect_x, effect_y);

        GameObject effectCopy = Object.Instantiate(Effect, vector, Quaternion.identity);
        

        //CharacterScript.finishMoveReqToManager();
        await UniTask.Delay((int)(0.8 * 1000));

        GameObject.Destroy(effectCopy);

    }
}
