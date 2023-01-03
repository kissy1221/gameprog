using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Cysharp.Threading.Tasks;

public abstract class CharacterTest : MonoBehaviour
{

    [SerializeField] Text text;
    [SerializeField] protected Text descriputionText;

    public enum State
    {
        START,
        WAIT,
        EXCUTE,
        FINISH
    }

    [SerializeField] public State status;
    [SerializeField] protected Gage gage;
    [SerializeField] protected EnemyManagerTest EnemyManager;


    public bool Allow = true;

    bool excuteAllow()
    {
        return Allow;
    }

    protected void Start()
    {
        status = State.START;
    }

    // Update is called once per frame
    protected void Update()
    {
        changeStatusText();
    }

    public abstract UniTask excute(int time);

    public void changeStatusText()
    {
        if(status==State.WAIT)
        {
            text.text = "�ҋ@��";
        }
        else if(status==State.EXCUTE)
        {
            text.text = "���s��";
        }
        else if(status==State.START)
        {
            text.text = "�J�n";
        }
        else if(status==State.FINISH)
        {
            text.text = "�I��";
        }
    }

}
