using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CommandDataBase", menuName = "CreateCommandDataBase")]
public class CommandDB : ScriptableObject
{
    public List<CommandDate> commands = new List<CommandDate>();

    public List<CommandDate> getCommandDataBase()
    {
        return commands;
    }
}
