using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

using Const;

public class WarpSword : Command
{

    public WarpSword(GameObject characterObj) : base(characterObj)
    {
        date = Resources.Load(CO.PATH.COMMAND_ENEMY+"WarpSword") as CommandDate ;
    }

    public override async UniTask excute()
    {
        Vector2Int AttackObjectPos;//攻撃対象座標
        Vector2Int movePos; //移動地点
        Vector2Int nowPos;  //発動地点

        nowPos = CharacterObject.getMapPosition();

        if (CharacterObject.tag=="Player")
        {
            AttackObjectPos = GameObject.FindGameObjectWithTag("Enemy").getMapPosition();
            movePos = new Vector2Int(AttackObjectPos.x - 1, AttackObjectPos.y);
        }
        else
        {

            AttackObjectPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Character>().beforePos;
            movePos = new Vector2Int(AttackObjectPos.x + 1, AttackObjectPos.y);
            
        }


        //移動先の物体の判定
        if (map[movePos.x, movePos.y].getGameObjectOnFloor() is null)
        {
            CharacterObject.GetComponent<Move>().moveAt(movePos.x, movePos.y);

            CharacterObject.transform.Find("EnemyObject").gameObject.GetComponent<Animator>().SetTrigger("Sword");//アニメーション実行

            if (map[movePos.x - 1, movePos.y].getGameObjectOnFloor()!=null)
                map[movePos.x -1, movePos.y].getGameObjectOnFloor().GetComponent<Object>().Damage(date.atk);

            await UniTask.Delay((int)(0.7 * 1000));

            if(CharacterObject!=null)
                CharacterObject.GetComponent<Move>().moveAt(nowPos.x, nowPos.y);

            await UniTask.Delay((int)(0.3f * 1000));

        }
        else
        {
            await UniTask.Delay((int)(CO.COMMAND_WAIT_TIME * 1000));
        }
            
    }
}
