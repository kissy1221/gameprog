using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private float speed = 5;
    private float distance=1.26f;//移動距離
    private Vector2 direction;  //移動方向
    protected Vector3 targetPos; //移動目的地

    public bool movement = false;//アクション（移動・攻撃）中か

    public CommandList commandList;

    protected void Start()
    {
        targetPos = transform.position;
        
    }

    protected void Update()
    {
        if (!isAction() && GameManager.instance.isRunning())
        {
            commandList.run();
        }

        move();
    }

    protected void move()
    {

        if(direction!=Vector2.zero&&transform.position==targetPos)
        {
            targetPos += new Vector3(direction.x * distance, direction.y * distance, 0);
            
        }
        if(transform.position!=targetPos)
            MoveTo(targetPos);

        direction = Vector2.zero;


    }

    private void MoveTo(Vector3 targetPosition)
    {

        //movement = true;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);


        if (transform.position == targetPosition)
        {

            movement = false;
        }

    }

    public bool isAction()
    {
        return movement;
    }

    public void left()
    {
        direction.x = -1;
    }

    public void right()
    {
        direction.x = 1;
    }

    public void up()
    {
        direction.y = 1;
    }

    public void down()
    {
        direction.y = -1;
    }
    
    public void finishReqToManager(string charTag)
    {
        GameManager.instance.setFinishReq(charTag, true);
    }
}
