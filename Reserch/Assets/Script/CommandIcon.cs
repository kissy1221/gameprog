using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommandIcon : MonoBehaviour
{
    protected List<string> list;
    protected Character characterScript;


    //画像
    public Sprite ImageUp;
    public Sprite ImageDown;
    public Sprite ImageLeft;
    public Sprite ImageRight;

    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {

        list = characterScript.commandList.returnList();//コマンドリスト取得
        updateCommandListUI();
        

    }

    private void updateCommandListUI()
    {
        if (characterScript.commandList.update)
        {

            deleteCommandListIcon();

            foreach (string command in list)
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

                switch (command)
                {
                    case "up":
                        nullImageHead.sprite = ImageUp;
                        break;
                    case "down":
                        nullImageHead.sprite = ImageDown;
                        break;
                    case "left":
                        nullImageHead.sprite = ImageLeft;
                        break;
                    case "right":
                        nullImageHead.sprite = ImageRight;
                        break;

                }
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
