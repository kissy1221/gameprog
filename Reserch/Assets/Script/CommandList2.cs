using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        List.Add(com);
        update = true;
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

    public List<Command> returnList()
    {
        return List;
    }

}
