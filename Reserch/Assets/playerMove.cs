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
        /*
            //“ü—Í
           float commandX  = Input.GetAxisRaw("Horizontal");
           float commandY = Input.GetAxisRaw("Vertical");
            //        if (move != Vector2.zero && Vector3.Distance(transform.position, targetPos) < 0.5f)

            if (commandX == 1) right();
            else if (commandX == -1) left();
            else move.x = 0;

            if (commandY == 1) up();
            else if (commandY == -1) down();
            else move.y = 0;

            */

        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            commandList.push("left");
        }
        
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            commandList.push("right");
        }
        if(Input.GetKeyDown(KeyCode.Delete))
        {
            commandList.pop();
        }

        commandList.printList();

        if (move != Vector2.zero && transform.position == targetPos)
        {
            targetPos += new Vector3(move.x * distance, move.y * distance, 0);
        }

        Move(targetPos);
    }
    private void Move(Vector3 targetPosition)
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
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
