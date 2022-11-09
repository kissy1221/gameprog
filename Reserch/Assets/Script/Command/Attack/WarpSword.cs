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
        if(CharacterObject.tag=="Player")
        {
            Vector2Int EnemyPos=GameObject.FindGameObjectWithTag("Enemy").getMapPosition();
            Vector2Int movePos = new Vector2Int(EnemyPos.x - 1, EnemyPos.y);
            Vector2Int nowPos = GameObject.FindGameObjectWithTag("Player").getMapPosition();

            Debug.Log("à⁄ìÆêÊ:" + movePos);

            CharacterObject.GetComponent<Move>().moveAt(movePos.x, movePos.y);

            if (map[movePos.x+1, movePos.y].getGameObjectOnFloor() != null)
            {
                map[movePos.x + 1, movePos.y].getGameObjectOnFloor().GetComponent<Object>().Damage(Power);

                Debug.Log("Ç‡Ç∆ÇÃà íuÇ…ñﬂÇËÇ‹Ç∑");
                CharacterObject.GetComponent<Move>().moveAt(nowPos.x, nowPos.y);


            }
        }
        else
        {

        }
    }
}
