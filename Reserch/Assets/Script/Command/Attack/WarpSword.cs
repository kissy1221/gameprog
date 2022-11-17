using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class WarpSword : Command
{
    int Power = 50;

    public WarpSword(GameObject characterObj) : base(characterObj)
    {

        name = "Sword";
        Image = Resources.Load<Sprite>("Images/Sword");
    }

    public override void excute()
    {
        //playerの場合の動作
        if(CharacterObject.tag=="Player")
        {
            Vector2Int EnemyPos=GameObject.FindGameObjectWithTag("Enemy").getMapPosition();//敵の位置取得
            Vector2Int movePos = new Vector2Int(EnemyPos.x - 1, EnemyPos.y);
            Vector2Int nowPos = GameObject.FindGameObjectWithTag("Player").getMapPosition();

            Debug.Log("移動先:" + movePos);

            //敵の前に移動状態
            CharacterObject.GetComponent<Move>().moveAt(movePos.x, movePos.y);

            //物体がいたら
            if (map[movePos.x+1, movePos.y].getGameObjectOnFloor() != null)
            {
                map[movePos.x + 1, movePos.y].getGameObjectOnFloor().GetComponent<Object>().Damage(Power);

                Debug.Log("もとの位置に戻ります");
                CharacterObject.GetComponent<Move>().moveAt(nowPos.x, nowPos.y);


            }

            //元の位置に戻る
        }
        else
        {

        }
    }
}
