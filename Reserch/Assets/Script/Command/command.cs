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

    protected GameObject CharacterObject;//�R�}���h���s��

    protected GameObject mapObj;
    protected Map map;

    //����:�R�}���h���s��
    public Command(GameObject characterObj)
    {
        this.CharacterObject = characterObj;
        this.MoveSciprt = CharacterObject.GetComponent<Move>();
        this.CharacterScript = CharacterObject.GetComponent<Character>();

        map = GameObject.FindGameObjectWithTag("Map").GetComponent<Map>();

    }


    //���s
    public abstract void excute();



}
