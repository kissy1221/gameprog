using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Const;

public class CommandList2
{
    private List<Command> List = new List<Command>();

    public int Count
    {
        get
        {
            return List.Count;
        }
    }

    public bool update = false; //リストが更新されたか

    public string getListstr()
    {
        string str ="";

        foreach(Command i in List)
        {
            str += i.GetType().Name;
            str += "=>";
        }

        return str;
    }

    public void add(Command com)
    {
        if (Count < Const.CO.MAX_COMMAND_LIST_SIZE) 
        {
            List.Add(com);
            update = true;
        }
        else
        {
            Debug.Log("追加できません");
        }

    }

    public Command getFrom(int i)
    {
        return List[i];
    }

    public void removeTail()
    {
        List.RemoveAt(Count- 1);
        update = true;
    }

    public void removeHead()
    {
        List.RemoveAt(0);
        update = true;
    }

    public void swap(int index1,int index2)
    {
        if(List.Count<=index1||List.Count<=index2)
        {
            return;
        }

        Command temp = List[index1];
        List[index1] = List[index2];
        List[index2] = temp;

        update = true;
    }

    public List<Command> returnList()
    {
        return List;
    }

    public void deleteAll()
    {
        List.Clear();
        update = true;
    }
        

}
