using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    [SerializeField] private float speed;
    private float distance;
    private Vector2 move;
    private Vector3 targetPos;

    private CommandList commandList;
    private void Start()
    {
        distance = 1.26f;
        targetPos = transform.position;

        commandList = new CommandList();
    }
    void Update()
    {

        input();

        //commandList.printList();

        if (move != Vector2.zero && transform.position == targetPos)
        {
            targetPos += new Vector3(move.x * distance, move.y * distance, 0);
        }

        Move(targetPos);

        move.x = 0;
        move.y = 0;
    }
    private void Move(Vector3 targetPosition)
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
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
            commandList.run();
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
