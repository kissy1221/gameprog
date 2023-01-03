using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//�L�����N�^�[(�G�A�v���C���[)�ɃR���|�[�l���g�Ƃ��ĕt����n�̃R�}���h���X�g
public class CommandList : MonoBehaviour
{

    private SelectableList<Command> List=new SelectableList<Command>();

    [SerializeField]GameObject commandListUI; //�R�}���h���X�g�̕\����UI

    public int Count { get { return List.Count; } }

    // Start is called before the first frame update
    void Start()
    {

        //���X�g���X�V���ꂽ�Ƃ��ɌĂяo���R�[���o�b�N�֐��̓o�^
        List.mChanged += () => updateCommandListUI(); //UI�ɕ\������֐���o�^����

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
        List.RemoveAt(Count - 1);
    }

    //�擪����菜��
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
                Image nullImageHead = null; //CommandImage���\������Ă��Ȃ��擪�摜
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
