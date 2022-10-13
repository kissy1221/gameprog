using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command
{
    public string name;
    private string type;
    public Sprite Image;

    protected string charTag;

    protected Character CharacterScript;

    protected GameObject mapObj;
    protected Map map;

    public Command(Character character)
    {
        this.CharacterScript = character;
        map = GameObject.FindGameObjectWithTag("Map").GetComponent<Map>();

    }


    //é¿çs
    public abstract void excute();

}
