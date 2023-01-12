using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Samurai : Enemy
{
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        pushCommandListAtRondom();
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
    }

    public override void pushCommandListAtRondom()
    {
        int CommandNum = Random.Range(2, 6);

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
                    commandList.Add(new Swap(this.gameObject));
                    break;
                case 6:
                    commandList.Add(new WarpSword(this.gameObject));
                    break;
            }
        }

    }
}
