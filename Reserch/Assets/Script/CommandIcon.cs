using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommandIcon:MonoBehaviour
{
    protected List<Command> list;
    protected Character characterScript;


    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {

        list = characterScript.commandList.returnList();
        updateCommandListUI();
        

    }

    private void updateCommandListUI()
    {
        if (characterScript.commandList.update)
        {

            deleteCommandListIcon();

            foreach (Command command in list)
            {
                Image nullImageHead = null; //CommandImageが表示されていない先頭画像
                foreach (Transform child in gameObject.transform)
                {
                    if (child.gameObject.GetComponent<Image>().sprite == null)
                    {
                        nullImageHead = child.gameObject.GetComponent<Image>();
                        break;
                    }
                }

                nullImageHead.sprite = command.Image;

            }
            characterScript.commandList.update = false;

        }
    }

    //表示されているコマンドアイコンをすべて削除
    private void deleteCommandListIcon()
    {
        foreach (Transform child in gameObject.transform)
        {
            child.gameObject.GetComponent<Image>().sprite = null;
        }
    }
}
