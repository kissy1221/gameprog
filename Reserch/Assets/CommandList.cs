using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandList : MonoBehaviour
{

    //private List<Command> commandList = new List<Command>();

    private List<string> commandStr = new List<string>();

    public GameObject player;
    private playerMove playerScript;

    public CommandList()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<playerMove>();

    }


    public void push(string commandName)
    {
        commandStr.Add(commandName);
    }

    public void pop()
    {
        if(commandStr.Count>0)
            commandStr.RemoveAt(commandStr.Count - 1);
    }

    public void run()
    {
        while(commandStr.Count>0)
        {

            //èàóù//
            if (commandStr[0] == "up")
                playerScript.up();
            if (commandStr[0] == "left")
                playerScript.down();
            if (commandStr[0] == "right")
                playerScript.right();
            if (commandStr[0] == "down")
                playerScript.down();
            ///////
            commandStr.RemoveAt(0);
        }

    }

    public void removeHead()
    {
        commandStr.RemoveAt(0);

        
    }



    public void printList()
    {
        Debug.Log(string.Join(",",commandStr));
    }

}
