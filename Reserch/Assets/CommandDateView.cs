using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommandDateView : MonoBehaviour
{
    Text commandText;
    Text typeText;
    Text attackText;
    Text costText;

    Button deleteButton;

    [SerializeField]CommandDate date;

    // Start is called before the first frame update
    void Start()
    {
        //子オブジェクトのTextオブジェクトを取得
        commandText = transform.Find("Command").gameObject.GetComponent<Text>();
        typeText= transform.Find("Type").gameObject.GetComponent<Text>();
        attackText= transform.Find("Attack").gameObject.GetComponent<Text>();
        costText= transform.Find("Cost").gameObject.GetComponent<Text>();
        deleteButton = transform.Find("DeleteButton").gameObject.GetComponent<Button>();

        //CommandDateクラスから取得
        commandText.text = date.commandName;
        typeText.text = date.type.ToString();
        attackText.text = date.atk.ToString();
        costText.text = date.cost.ToString();

        if((date.type!=CommandDate.commandType.Atack)&&date.atk==0)
        {
            attackText.text = "-";
        }

        if(date.type==CommandDate.commandType.Backbone)
        {
            deleteButton.interactable = false;
            typeText.text = "基幹";
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onClickDeleteButton()
    {
        Destroy(this.gameObject);
    }
}
