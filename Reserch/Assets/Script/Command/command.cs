using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

public abstract class Command
{
    public CommandDate date;

    //削除予定
    public string name;
    private string type;
    public Sprite Image;

    protected Character CharacterScript;
    protected Move MoveSciprt;

    protected GameObject CharacterObject;//コマンド実行者

    protected CommandList2 commandList;

    protected GameObject mapObj;
    protected Floor[,] map;

    //引数:コマンド実行者
    public Command(GameObject characterObj)
    {
        this.CharacterObject = characterObj; //コマンド実行者
        this.MoveSciprt = CharacterObject.GetComponent<Move>();
        this.CharacterScript = CharacterObject.GetComponent<Character>();


        this.commandList = CharacterScript.commandList;

        map = GameObject.FindGameObjectWithTag("Map").GetComponent<Map>().getMap();

    }

    public abstract UniTask excute();

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



}
