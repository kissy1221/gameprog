using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComListOnDeck : MonoBehaviour
{



    // Start is called before the first frame update
    void Start()
    {

        loadCommandList();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void loadCommandList()
    {
        CommandDB commandDB = Resources.Load(Const.CO.PATH.COMMAND_DB) as CommandDB;
        GameObject valueObj = Resources.Load("Prefab/BuildDeckScene/CommandsValue") as GameObject;

        foreach (CommandDate data in commandDB.getCommandDataBase())
        {
            if(data.type!=CommandDate.commandType.Backbone && data.user!=CommandDate.commandUser.Enemy)
            {
                GameObject obj = Instantiate(valueObj, Vector3.zero, Quaternion.identity, this.transform);//�e�I�u�W�F�N�g�w�肵�A�����B
                obj.GetComponent<CommandListValue>().Date = data;//���������I�u�W�F�N�g�ɑΏۃR�}���h�f�[�^��n���B
            }

        }
    }


}
