using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command
{
    public string name;
    private string type;
    public Sprite Image;

    protected GameObject Character;   //�R�}���h�̎��s�Ώ�(�v���C���[ or Enemy)
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


    //���s
    public abstract void excute();

}
