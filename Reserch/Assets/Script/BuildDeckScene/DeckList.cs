using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class DeckList : MonoBehaviour
{

    public SelectableList<CommandDate> deck = new SelectableList<CommandDate>(); //更新されるたびにコールバック関数をする

    private void Start()
    {
        // リストが変更された時に呼び出されるコールバック関数を登録
        deck.mChanged += () => printDeckOnView();

        initDeck();
        
    }

    private void Update()
    {

        if(Input.GetKeyDown(KeyCode.N))
        {
            printDeckOnConsole();
        }
    }

    void printDeckOnConsole()
    {
        string str="";
        for (int i = 0; i < deck.Count;i++)
        {
            str += deck[i].commandName + ",";
        }

        Debug.Log(str);
    }

    void printDeckOnView()
    {
        GameObject contentObj = transform.Find("ScrollView/Viewport/Content").gameObject;
        GameObject valueObj = Resources.Load("Prefab/BuildDeckScene/value") as GameObject;
        GameObject line = Resources.Load("Prefab/BuildDeckScene/Line") as GameObject;

        //オブジェクトの削除
        foreach(Transform n in contentObj.transform)
        {
            GameObject.Destroy(n.gameObject);
        }

        Debug.Log("削除");

        //基幹コマンドのみ
        foreach(CommandDate comDate in deck)
        {
            if(comDate.type==CommandDate.commandType.Backbone)
            {
                GameObject obj = Instantiate(valueObj, Vector3.zero, Quaternion.identity, contentObj.transform);//親オブジェクト指定し、生成。
                obj.GetComponent<DeckListValue>().Date = comDate;//生成したオブジェクトに対象コマンドデータを渡す。
            }
        }

        Debug.Log("基幹コマンド配置");

        //線引き
        Instantiate(line, Vector3.zero, Quaternion.identity, contentObj.transform);
        Debug.Log("線引き");

        foreach (CommandDate comDate in deck)
        {
            if (comDate.type != CommandDate.commandType.Backbone)
            {
                GameObject obj = Instantiate(valueObj, Vector3.zero, Quaternion.identity, contentObj.transform);//親オブジェクト指定し、生成。
                obj.GetComponent<DeckListValue>().Date = comDate;//生成したオブジェクトに対象コマンドデータを渡す。
            }
        }

        Debug.Log("コマンド配置");
    }


    //�f�b�L��������(��R�}���h�݂̂ɂ���)
    public void initDeck()
    {
        Debug.Log("デッキ初期化");
        CommandDate[] array = Resources.LoadAll<CommandDate>("CommandDate/BackBorne");

        deck.Clear();

        deck.copy(array.ToList());
    }

}
