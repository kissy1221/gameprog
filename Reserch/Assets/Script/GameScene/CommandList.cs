using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//�L�����N�^�[(�G�A�v���C���[)�ɃR���|�[�l���g�Ƃ��ĕt����n�̃R�}���h���X�g
public class CommandList : MonoBehaviour
{

    private SelectableList<Command> List=new SelectableList<Command>();

    [SerializeField] public GameObject commandListUI; //�R�}���h���X�g�̕\����UI

    public int Count { get { return List.Count; } }

    // Start is called before the first frame update
    void Start()
    {
        
        if (this.commandListUI == null)
        {
            GameObject horizontalList = Resources.Load("Prefab/UI/EnemyCommandIcon") as GameObject;
            GameObject enemyCommandListView = GameObject.Find("EnemyCommandListView");
            commandListUI=Instantiate(horizontalList, Vector3.zero, Quaternion.identity, enemyCommandListView.transform);
        }
        

        //���X�g���X�V���ꂽ�Ƃ��ɌĂяo���R�[���o�b�N�֐��̓o�^
        List.mChanged += () => updateCommandListUI(); //UI�ɕ\������֐���o�^����

    }

    public void printListOnCosole()
    {
        string str="";
        foreach(Command com in List)
        {
            str += com.date.name+"=>";
        }

        Debug.Log(str);
    }

    public void Add(Command com)
    {
        if (Count < Const.CO.MAX_COMMAND_LIST_SIZE)
        {
            List.Add(com);
        }
        else
        {
            Debug.Log("�ǉ��ł��܂���");
        }
    }

    //�������菜��
    public void removeTail()
    {
        if(List.Count>0)
            List.RemoveAt(Count - 1);
    }

    //�擪����菜��
    public void removeHead()
    {
        if(List.Count>0)
            List.RemoveAt(0);
    }

    public void removeAt(int i)
    {
        List.RemoveAt(i);
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





    public void updateCommandListUI()
    {
        foreach (Transform child in commandListUI.transform)
        {
            child.gameObject.GetComponent<Image>().sprite = null;
            child.GetChild(0).gameObject.SetActive(false);
        }

            foreach (Command command in List)
            {
                Image nullImageHead = null; //CommandImage���\������Ă��Ȃ��擪�摜
                foreach (Transform child in commandListUI.transform)
                {
                    if (child.gameObject.GetComponent<Image>().sprite == null)
                    {
                        nullImageHead = child.gameObject.GetComponent<Image>();
                        break;
                    }
                }

            if(command.GetType()==typeof(If))
            {
                nullImageHead.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            }

            nullImageHead.sprite = command.date.sprite;

            }
    }

    public int indexOf(Command com)
    {
        return List.IndexOf(com);
    }



    //�\���`�F�b�N
    public bool checkSynax()
    {

        int siz = 0 ; //����������Ɏg������

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
