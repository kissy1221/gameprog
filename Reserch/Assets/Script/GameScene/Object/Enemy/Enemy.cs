using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;

public class Enemy : Character
{
    Animator anim;

    [SerializeField]EnemyData Data;

    public EnemyData getData()
    {
        return Data;
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        anim = transform.Find("EnemyObject").gameObject.GetComponent<Animator>();

        
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        commandList.commandListUI.transform.Find("FaceIcon").gameObject.GetComponent<Image>().sprite = Data.Icon;


        if(Input.GetKeyDown(KeyCode.Return))
        {
            Damage(100);
        }

    }

    //ランダムでリストにコマンドを入れる
    public virtual void pushCommandListAtRondom()
    {
        int CommandNum=Random.Range(2,6);

        for(int i=0;i<CommandNum;i++)
        {
            int RandomNum = Random.Range(1, 5);

            switch(RandomNum)
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
