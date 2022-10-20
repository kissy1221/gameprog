using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command
{
    public string name;
    private string type;
    public Sprite Image;

    protected Character CharacterScript;
    protected Move MoveSciprt;

    protected GameObject CharacterObject;//コマンド実行者

    protected GameObject mapObj;
    protected Map map;

    //引数:コマンド実行者
    public Command(GameObject characterObj)
    {
        this.CharacterObject = characterObj;
        this.MoveSciprt = CharacterObject.GetComponent<Move>();
        this.CharacterScript = CharacterObject.GetComponent<Character>();

        map = GameObject.FindGameObjectWithTag("Map").GetComponent<Map>();

    }


    //実行
    public abstract void excute();



}
