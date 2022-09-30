using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    private float speed=5;
    private float distance;
    private Vector2 move;
    private Vector3 targetPos; //移動目的地

    private bool movement = false;//アクション（移動・攻撃）中か


    public CommandList commandList;
    private void Start()
    {
        distance = 1.26f;
        targetPos = transform.position;

        commandList = new CommandList("Player");　//実行後、コマンドリストのインスタンスを作成
    }
    void Update()
    {
        if(!commandList.isRunning())
            input();

        if (movement == false && commandList.isRunning()) 
            commandList.run();

        if (move != Vector2.zero && transform.position == targetPos)
        {
            targetPos += new Vector3(move.x * distance, move.y * distance, 0);
        }

        Move(targetPos);

        move = Vector2.zero;
    }
    private void Move(Vector3 targetPosition)
    {
        movement = true;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        if (transform.position == targetPosition)
        {
            movement = false;
        }


    }

    private void input()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            commandList.push("left");
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            commandList.push("right");
        }

        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            commandList.push("up");
        }
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            commandList.push("down");
        }

        if (Input.GetKeyDown(KeyCode.Delete))
        {
            commandList.pop();
        }

        if(Input.GetKeyDown(KeyCode.Return))
        {
            commandList.switchRun(true);
        }

        if(Input.GetKeyDown(KeyCode.P))
        {
            commandList.printList();
        }
    }

    public void left()
    {
        move.x = -1;
    }

    public void right()
    {
        move.x = 1;
    }

    public void up()
    {
        move.y = 1;
    }

    public void down()
    {
        move.y = -1;
    }

}
