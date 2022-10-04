using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandList : MonoBehaviour
{

    /// <summary>
    private List<Command> commandList = new List<Command>();
    /// </summary>

    private List<string> commandStr = new List<string>();

    public GameObject Character;   //�v���C���[�I�u�W�F�N�g
    private Character CharacterScript;
    public string CharTag=null; //�L�����N�^�[�̎��


    public bool update=false;

    public CommandList(string CharacterTag)
    {
        Debug.Log("�R���X�g���N�^�[");

        CharTag = CharacterTag;
        if(CharTag=="Player")
        {
            Character = GameObject.FindGameObjectWithTag(CharacterTag);
            CharacterScript = Character.GetComponent<playerMove>();


        }
        else if(CharTag=="Enemy")
        {
            Character=GameObject.FindGameObjectWithTag(CharacterTag);
            CharacterScript = Character.GetComponent<Enemy>();
        }

    }

    public List<string> returnList()
    {
        return commandStr;
    }

    public void push(string commandName)
    {
        commandStr.Add(commandName);

        update = true;
    }

    public void push(Command command)
    {
        commandList.Add(command);
        update = true;
    }

    public void pop()
    {
        if(commandStr.Count>0)
            commandStr.RemoveAt(commandStr.Count - 1);
        update = true;
    }

    public void run()
    {
        if(commandStr.Count>0)
        {

            switch(commandStr[0])
            {
                case "up":
                    CharacterScript.up();
                    CharacterScript.movement = true;
                    break;
                case "left":
                    CharacterScript.left();
                    CharacterScript.movement = true;
                    break;
                case "right":
                    CharacterScript.right();
                    CharacterScript.movement = true;
                    break;
                case "down":
                    CharacterScript.down();
                    CharacterScript.movement = true;
                    break;
            }

            commandStr.RemoveAt(0);
            update = true;


        }

        //�R�}���h���X�g����A�����Ă��Ȃ����Ƀ��N�G�X�g���M
        if (commandStr.Count <= 0 && CharacterScript.isAction() == false)
        {
            Debug.Log(CharTag + "���I�����N�G�X�g�𑗂�܂���");
            CharacterScript.finishReqToManager(CharTag);
        }

    }

    

    public void removeHead()
    {
        commandStr.RemoveAt(0);

        
    }



    public void printList()
    {
        Debug.Log("����:"+string.Join("��",commandStr));
    }

}
