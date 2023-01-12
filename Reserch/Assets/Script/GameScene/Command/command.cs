using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

public abstract class Command
{
    public CommandDate date;//�R�}���h�̃f�[�^

    //�R�}���h���s�҃X�N���v�g
    protected GameObject CharacterObject;//�R�}���h���s��
    protected Character CharacterScript;
    protected Move MoveSciprt;

    protected CommandList commandList;

    //Map�n
    protected GameObject mapObj;
    protected Floor[,] map;

    public GameObject getExcuteObject()
    {
        return CharacterObject;
    }

    //����:�R�}���h���s��
    public Command(GameObject characterObj)
    {
        this.CharacterObject = characterObj; //�R�}���h���s��
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
