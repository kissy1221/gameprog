using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : Enemy
{
    protected void Start()
    {
        base.Start();
        pushCommandListAtRondom();
    }

    // Update is called once per frame
    protected void Update()
    {
        base.Update();
    }

    public override void pushCommandListAtRondom()
    {
        int CommandNum = Random.Range(7, 10);

        for (int i = 0; i < CommandNum; i++)
        {
            int RandomNum = Random.Range(1, 7);

            switch (RandomNum)
            {
                case 1:
                    commandList.Add(new Up(this.gameObject));
                    break;
                case 2:
                    commandList.Add(new Left(this.gameObject));
                    break;
                case 3:
                    commandList.Add(new Right(this.gameObject));
                    break;
                case 4:
                    commandList.Add(new Down(this.gameObject));
                    break;
                case 5:
                    commandList.Add(new Bomb(this.gameObject));
                    break;
                case 6:
                    int numX, numY;
                    while(true)
                    {
                        numX = Random.Range(0, 4);
                        numY = Random.Range(0, 4);

                        if (Map.Instance.getMap()[numX, numY].getGameObjectOnFloor() == null && Map.Instance.getMap()[numX, numY].getGameObjectOnFloorSub()==null)
                            break;
                    }
                    commandList.Add(new Mine(this.gameObject, new Vector2Int(numX, numY)));
                    break;
            }
        }

    }
}
