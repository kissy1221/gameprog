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
                GameObject obj = Instantiate(valueObj, Vector3.zero, Quaternion.identity, this.transform);//親オブジェクト指定し、生成。
                obj.GetComponent<CommandListValue>().Date = data;//生成したオブジェクトに対象コマンドデータを渡す。
            }

        }
    }


}
