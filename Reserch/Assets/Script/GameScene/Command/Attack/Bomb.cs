using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using Const;

public class Bomb : Command
{
    public Bomb(GameObject characterObj) : base(characterObj)
    {
        date = Resources.Load(CO.PATH.COMMAND + "common/Bomb") as CommandDate;
    }

    public override async UniTask excute()
    {
        Vector2Int DamageArea;
        Vector2Int excutePos;
        GameObject Bomb=Resources.Load(CO.PATH.PREFAB+"Bomb") as GameObject;//ロード

        excutePos = CharacterObject.getMapPosition();
        DamageArea = excutePos;

        if (CharacterObject.tag=="Player")
        {
            Object.Instantiate(Bomb, CharacterObject.transform.position, Quaternion.identity);

            DamageArea.x += 3;
        }
        else
        {
            GameObject BombCopy = Object.Instantiate(Bomb, CharacterObject.transform.position, Quaternion.identity);
            BombScript bombScript = BombCopy.GetComponent<BombScript>();

            bombScript.vector.x = -bombScript.vector.x;
            bombScript.rotateSpeed = -bombScript.rotateSpeed;
            DamageArea.x -= 3;
        }

        await UniTask.Delay(800);
        
        //ここでダメージ計算
        if(Map.Instance.getFloor(DamageArea.x,DamageArea.y).getGameObjectOnFloor()!=null)
        {
            Map.Instance.getFloor(DamageArea.x, DamageArea.y).getGameObjectOnFloor().GetComponent<Object>().Damage(date.atk);
        }

    }

}
