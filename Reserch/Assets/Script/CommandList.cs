using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandList : MonoBehaviour
{

    private List<string> commandStr = new List<string>();

    public GameObject player;   //�v���C���[�I�u�W�F�N�g
    private Character playerScript;

    public string CharTag=null;


    public bool update=false;

    public CommandList(string CharacterTag)
    {
        CharTag = CharacterTag;
        if(CharTag=="Player")
        {
            player = GameObject.FindGameObjectWithTag(CharacterTag);
            playerScript = player.GetComponent<playerMove>();


        }
        else if(CharTag=="Enemy")
        {
            player=GameObject.FindGameObjectWithTag(CharacterTag);
            playerScript = player.GetComponent<Enemy>();
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
                    playerScript.up();
                    playerScript.movement = true;
                    break;
                case "left":
                    playerScript.left();
                    playerScript.movement = true;
                    break;
                case "right":
                    playerScript.right();
                    playerScript.movement = true;
                    break;
                case "down":
                    playerScript.down();
                    playerScript.movement = true;
                    break;
            }

            commandStr.RemoveAt(0);
            update = true;


        }

        //�R�}���h���X�g����A�����Ă��Ȃ����Ƀ��N�G�X�g���M
        if (commandStr.Count <= 0 && playerScript.isAction() == false)
        {
            Debug.Log(CharTag + "���I�����N�G�X�g�𑗂�܂���");
            playerScript.finishReqToManager(CharTag);
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
