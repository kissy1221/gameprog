using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        pushCommandListAtRondom();
        setHP(500);
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
        
    }

    //ランダムでリストにコマンドを入れる
    public void pushCommandListAtRondom()
    {
        int CommandNum=Random.Range(5,6);

        for(int i=0;i<CommandNum;i++)
        {
            int RandomNum = Random.Range(1, 6);

            switch(RandomNum)
            {
                case 1:
                    commandList.add(new Up(this.gameObject));
                    break;
                case 2:
                    commandList.add(new Left(this.gameObject));
                    break;
                case 3:
                    commandList.add(new Right(this.gameObject));
                    break;
                case 4:
                    commandList.add(new Down(this.gameObject));
                    break;
                case 5:
                    commandList.add(new Swap(this.gameObject));
                    break;
            }
        }

    }
}
