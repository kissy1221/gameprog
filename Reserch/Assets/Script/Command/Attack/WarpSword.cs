using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

using Const;

public class WarpSword : Command
{
    int Power = 50;

    public WarpSword(GameObject characterObj) : base(characterObj)
    {
        date = Resources.Load(CO.PATH.COMMAND_ENEMY+"WarpSword") as CommandDate ;
    }

    public override async UniTask excute()
    {
        Vector2Int AttackObjectPos;//�U���Ώۍ��W
        Vector2Int movePos; //�ړ��n�_
        Vector2Int nowPos;  //�����n�_

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

        Debug.Log("�U���Ώۍ��W" + AttackObjectPos);
        Debug.Log("�ړ���:" + movePos);


        //�ړ���̕��̂̔���
        if (map[movePos.x, movePos.y].getGameObjectOnFloor() is null)
        {
            CharacterObject.GetComponent<Move>().moveAt(movePos.x, movePos.y);

            CharacterObject.transform.Find("EnemyObject").gameObject.GetComponent<Animator>().SetTrigger("Sword");

            if (map[movePos.x - 1, movePos.y].getGameObjectOnFloor()!=null)
                map[movePos.x -1, movePos.y].getGameObjectOnFloor().GetComponent<Object>().Damage(date.atk);

            await UniTask.Delay((int)(0.7 * 1000));

            Debug.Log("���Ƃ̈ʒu�ɖ߂�܂�");
            CharacterObject.GetComponent<Move>().moveAt(nowPos.x, nowPos.y);

            await UniTask.Delay((int)(0.3f * 1000));

        }
            
    }
}
