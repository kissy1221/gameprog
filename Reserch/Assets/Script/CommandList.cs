using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//キャラクター(敵、プレイヤー)にコンポーネントとして付ける系のコマンドリスト
public class CommandList : MonoBehaviour
{

    private SelectableList<Command> List=new SelectableList<Command>();

    [SerializeField]GameObject commandListUI; //コマンドリストの表示先UI

    public int Count { get { return List.Count; } }

    // Start is called before the first frame update
    void Start()
    {

        //リストが更新されたときに呼び出すコールバック関数の登録
        List.mChanged += () => updateCommandListUI(); //UIに表示する関数を登録する

    }

    public void Add(Command com)
    {
        if (Count < Const.CO.MAX_COMMAND_LIST_SIZE)
        {
            List.Add(com);
        }
        else
        {
            Debug.Log("追加できません");
        }
    }

    //後尾を取り除く
    public void removeTail()
    {
        List.RemoveAt(Count - 1);
    }

    //先頭を取り除く
    public void removeHead()
    {
        List.RemoveAt(0);
    }

    public Command getFrom(int i)
    {
        return List[i];
    }

    public void clear()
    {
        List.Clear();
    }

    public void swap(int index1, int index2)
    {
        if (List.Count <= index1 || List.Count <= index2)
        {
            return;
        }

        Command temp = List[index1];
        List[index1] = List[index2];
        List[index2] = temp;
    }





    private void updateCommandListUI()
    {

        foreach (Transform child in commandListUI.transform)
        {
            child.gameObject.GetComponent<Image>().sprite = null;
        }

            foreach (Command command in List)
            {
                Image nullImageHead = null; //CommandImageが表示されていない先頭画像
                foreach (Transform child in commandListUI.transform)
                {
                    if (child.gameObject.GetComponent<Image>().sprite == null)
                    {
                        nullImageHead = child.gameObject.GetComponent<Image>();
                        break;
                    }
                }

            nullImageHead.sprite = command.date.sprite;

            }
    }

    //構文チェック
    public bool checkSynax()
    {

        int siz = 0 ; //整合性判定に使うもの

        foreach(Command com in List)
        {
            if(com.GetType() == typeof(If))
            {
                siz++;
            }
            else if(com.GetType() == typeof(End))
            {
                siz--;
            }

            if (siz < 0)
                return false;
        }

        if (siz != 0)
        {
            return false;
        }

        return true;
    }


}
