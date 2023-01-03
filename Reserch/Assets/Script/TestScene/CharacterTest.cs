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
            text.text = "待機中";
        }
        else if(status==State.EXCUTE)
        {
            text.text = "実行中";
        }
        else if(status==State.START)
        {
            text.text = "開始";
        }
        else if(status==State.FINISH)
        {
            text.text = "終了";
        }
    }

}
