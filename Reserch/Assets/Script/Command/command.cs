using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command
{
    public string name;
    private string type;
    public Sprite Image;

    protected GameObject Character;   //コマンドの実行対象(プレイヤー or Enemy)
    protected Character CharacterScript;

    public Command(string charTag)
    {
        if(charTag=="Player")
        {
            Character = GameObject.FindWithTag("Player");
            CharacterScript = Character.GetComponent<Character>();
        }
        else
        {
            Character = GameObject.FindWithTag("Enemy");
            CharacterScript = Character.GetComponent<Character>();
        }

    }


    //実行
    public abstract void excute();

}
