using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{

    public GameObject EnemyObject;
    public Enemy EnemyScript;

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        charTag = "Enemy";
        pushCommandListAtRondom();

        EnemyObject = GameObject.FindGameObjectWithTag("Enemy");
        EnemyScript = EnemyObject.GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
        
    }

    //ランダムでリストにコマンドを入れる
    public void pushCommandListAtRondom()
    {
        int CommandNum=Random.Range(4,5);

        for(int i=0;i<CommandNum;i++)
        {
            int RandomNum = Random.Range(1, 5);

            switch(RandomNum)
            {
                case 1:
                    commandList.add(new Up(this));
                    break;
                case 2:
                    commandList.add(new Left(this));
                    break;
                case 3:
                    commandList.add(new Right(this));
                    break;
                    
                case 4:
                    commandList.add(new Down(this));
                    break;
            }
        }

    }
}
