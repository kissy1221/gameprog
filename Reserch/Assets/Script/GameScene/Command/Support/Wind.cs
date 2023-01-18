using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Const;
using Cysharp.Threading.Tasks;

public class Wind : Command
{
    public Wind(GameObject characterObj) : base(characterObj)
    {
        date = Resources.Load(CO.PATH.COMMAND+"common/Wind") as CommandDate;
    }

    //ÉvÉåÉCÉÑÅ[ÇÃÇ›é¿ëï
    public override async UniTask excute()
    {
        List<GameObject> Enemies = EnemyManager.Instance.Enemies;

        foreach(GameObject Enemy in Enemies)
        {
            Move moveScript = Enemy.GetComponent<Move>();
            if(moveScript.canMove(new Vector2Int(1, 0)))
            {
                moveScript.right();
                Enemy.GetComponent<Character>().State.setState(CharacterState.State.MOVE);
            }
        }

        await UniTask.Delay((int)(CO.COMMAND_WAIT_TIME * 1000));

    }
}
