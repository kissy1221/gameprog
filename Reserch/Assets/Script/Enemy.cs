using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        commandList = new CommandList("Enemy"); //���s��A�R�}���h���X�g�̃C���X�^���X���쐬

    }

    // Update is called once per frame
    void Update()
    {

        if (!isAction() && GameManager.instance.isRunning())
        {
            commandList.run();
        }

        move();
    }

    //�����_���Ń��X�g�ɃR�}���h������
    private void pushCommandListAtRondom()
    {
        int CommandNum=Random.Range(1,8);

        for(int i=0;i<CommandNum;i++)
        {
            int RandomNum = Random.Range(1, 5);

            switch(RandomNum)
            {
                case 1:
                    commandList.push("up");
                    break;
                case 2:
                    commandList.push("left");
                    break;
                case 3:
                    commandList.push("right");
                    break;
                    
                case 4:
                    commandList.push("down");
                    break;
            }
        }

    }
}
