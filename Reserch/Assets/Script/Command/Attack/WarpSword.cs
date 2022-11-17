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

    public override async UniTask excute()
    {
        Vector2Int AttackObjectPos;//çUåÇëŒè€ç¿ïW
        Vector2Int movePos;
        Vector2Int nowPos;

        if(CharacterObject.tag=="Player")
        {
            AttackObjectPos = GameObject.FindGameObjectWithTag("Enemy").getMapPosition();
            movePos = new Vector2Int(AttackObjectPos.x - 1, AttackObjectPos.y);
            nowPos = GameObject.FindGameObjectWithTag("Player").getMapPosition();
        }
        else
        {
            AttackObjectPos = GameObject.FindGameObjectWithTag("Player").getMapPosition();
            movePos = new Vector2Int(AttackObjectPos.x + 1, AttackObjectPos.y);
            nowPos = GameObject.FindGameObjectWithTag("Enemy").getMapPosition();
        }

            Debug.Log("à⁄ìÆêÊ:" + movePos);

            //ìGÇÃëOÇ…à⁄ìÆèÛë‘
            CharacterObject.GetComponent<Move>().moveAt(movePos.x, movePos.y);

            //ï®ëÃÇ™Ç¢ÇΩÇÁ
            if (map[movePos.x+1, movePos.y].getGameObjectOnFloor() != null)
            {
                map[movePos.x + 1, movePos.y].getGameObjectOnFloor().GetComponent<Object>().Damage(Power);

                await UniTask.Delay((int)(0.7 * 1000));

                Debug.Log("Ç‡Ç∆ÇÃà íuÇ…ñﬂÇËÇ‹Ç∑");
                CharacterObject.GetComponent<Move>().moveAt(nowPos.x, nowPos.y);

                await UniTask.Delay((int)(0.3f * 1000));


            }
    }
}
