using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

public abstract class Command
{
    public CommandDate date;//コマンドのデータ

    //コマンド実行者スクリプト
    protected GameObject CharacterObject;//コマンド実行者
    protected Character CharacterScript;
    protected Move MoveSciprt;

    protected CommandList commandList;

    //Map系
    protected GameObject mapObj;
    protected Floor[,] map;

    public GameObject getExcuteObject()
    {
        return CharacterObject;
    }

    //引数:コマンド実行者
    public Command(GameObject characterObj)
    {
        this.CharacterObject = characterObj; //コマンド実行者
        this.MoveSciprt = CharacterObject.GetComponent<Move>();
        this.CharacterScript = CharacterObject.GetComponent<Character>();


        this.commandList = CharacterObject.GetComponent<CommandList>();

        map = Map.Instance.getMap();

    }

    public abstract UniTask excute();

    /*
    protected int searchCommandIndex()
    {
        List<Command> list = commandList.returnList();

        for(int i=0;i<commandList.Count;i++)
        {
            if(this==list[i])
            {
                return i;
            }
        }

        return -1;
    }

    */



}
