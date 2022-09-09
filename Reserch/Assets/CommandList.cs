using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandList : MonoBehaviour
{

    //private List<Command> commandList = new List<Command>();

    private List<string> commandStr = new List<string>();


    public void push(string commandName)
    {
        commandStr.Add(commandName);
    }

    public void pop()
    {
        commandStr.RemoveAt(commandStr.Count - 1);
    }

    public void run()
    {

    }



    public void printList()
    {
        Debug.Log(string.Join(",",commandStr));
    }

}
