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
        CommandDate[] dates;
        GameObject valueObj;

        dates = Resources.LoadAll<CommandDate>("CommandDate/Player"); //コマンド一覧をロード
        valueObj = Resources.Load("Prefab/BuildDeckScene/CommandsValue") as GameObject;

        for (int i = 0; i < dates.Length; i++)
        {
            GameObject obj = Instantiate(valueObj, Vector3.zero, Quaternion.identity, this.transform);//親オブジェクト指定し、生成。
            obj.GetComponent<CommandListValue>().Date = dates[i];//生成したオブジェクトに対象コマンドデータを渡す。
        }
    }


}
