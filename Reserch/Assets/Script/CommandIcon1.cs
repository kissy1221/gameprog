using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommandIcon1 : MonoBehaviour
{
    int num;
    Character characterScript;
    List<Command> list;
    Image image;
    
    // Start is called before the first frame update
    void Start()
    {
        num = int.Parse(this.gameObject.name.Substring(this.gameObject.name.Length - 1));
        if(this.gameObject.tag=="PlayerObj")
        {
            characterScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Character>();
            list = characterScript.commandList.returnList();
        }
        else
        {
            characterScript = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Character>();
            list = characterScript.commandList.returnList();
        }
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (list.Count >= num)
        {

        }
    }
}
