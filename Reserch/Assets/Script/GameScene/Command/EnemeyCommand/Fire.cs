using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using Const;

public class Fire : Command
{
    GameObject FireEffect;
    List<GameObject> FireEffects = new List<GameObject>();
    public Fire(GameObject characterObj) : base(characterObj)
    {
        date = Resources.Load(CO.PATH.COMMAND_ENEMY + "Fire") as CommandDate;
        FireEffect = Resources.Load(Const.CO.PATH.PREFAB + "Fire_B") as GameObject;
    }

    public override async UniTask excute()
    {
        Vector2Int characterPos = CharacterObject.getMapPosition();
        int x = characterPos.x -1;
        int y = characterPos.y;

        for (int i = x; i >= 0; i--)
        {
            GameObject AttackObj = map[i, y].getGameObjectOnFloor();
            Vector3 v = map[i, y].PlayerFloorPos;
            v.y -= 0.4f;
            FireEffects.Add(Object.Instantiate(FireEffect, v, Quaternion.identity));
            if (AttackObj!=null && AttackObj.tag!="Enemy")
            {
                AttackObj.GetComponent<Object>().Damage(date.atk);
            }
        }

        //CharacterScript.finishMoveReqToManager();
        await UniTask.Delay((int)(0.7 * 1000));

        foreach (GameObject fire in FireEffects)
            GameObject.Destroy(fire);
    }

}
