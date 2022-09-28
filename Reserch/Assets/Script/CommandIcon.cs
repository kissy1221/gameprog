using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommandIcon : MonoBehaviour
{
    private List<string> list;
    private playerMove playerScript;


    //âÊëú
    public Sprite ImageUp;
    public Sprite ImageDown;
    public Sprite ImageLeft;
    public Sprite ImageRight;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<playerMove>();

    }

    // Update is called once per frame
    void Update()
    {

        list = playerScript.commandList.returnList();

        if (playerScript.commandList.update)
        {

            foreach(Transform child in gameObject.transform)
            {
                child.gameObject.GetComponent<Image>().sprite = null;
            }

            foreach (string command in list)
            {
                Image nullImageHead = null; //CommandImageÇ™ï\é¶Ç≥ÇÍÇƒÇ¢Ç»Ç¢êÊì™âÊëú
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
            playerScript.commandList.update = false;

        }

        

    }
}
