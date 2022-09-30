using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandList : MonoBehaviour
{

    private List<string> commandStr = new List<string>();

    public GameObject player;   //プレイヤーオブジェクト
    private playerMove playerScript;

    private bool running = false; //コマンド実行中か
    public bool update=false;

    public CommandList()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<playerMove>();
    }

    public List<string> returnList()
    {
        return commandStr;
    }

    public void switchRun(bool enabled)
    {
        running = enabled;
    }

    public bool isRunning()
    {
        return running;
    }

    public void push(string commandName)
    {
        commandStr.Add(commandName);

        update = true;
    }

    public void pop()
    {
        if(commandStr.Count>0)
            commandStr.RemoveAt(commandStr.Count - 1);
        update = true;
    }

    public void run()
    {
        if(commandStr.Count>0)
        {

            //処理//
            if (commandStr[0] == "up")
                playerScript.up();
            if (commandStr[0] == "left")
                playerScript.left();
            if (commandStr[0] == "right")
                playerScript.right();
            if (commandStr[0] == "down")
                playerScript.down();
            ///////
            commandStr.RemoveAt(0);
            update = true;

            if (commandStr.Count <= 0)
            {
                switchRun(false);
            }
                

        }

    }

    

    public void removeHead()
    {
        commandStr.RemoveAt(0);

        
    }



    public void printList()
    {
        Debug.Log("入力:"+string.Join("→",commandStr));
    }

}
