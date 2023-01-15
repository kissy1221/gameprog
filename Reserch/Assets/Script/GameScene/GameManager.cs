using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;
using Const;

public class GameManager : MonoBehaviour
{

    int turn=1;

    [SerializeField]GameObject enemyDebugWindows;
    [SerializeField] Text StartText;

    public enum gameState
    {
        Run,    //Run中
        Command, //コマンド選択中
        GameClear,//ゲームクリアした
        GameOver//ゲームオーバーになった
    }

    public gameState State=gameState.Command;

    public static GameManager instance = null;

    GameObject PlayerObject;
    [SerializeField]GameObject Enemies;


    [SerializeField] public GameObject commandwin;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

        PlayerObject = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        StartText.text = $"{turn} TURN START!";

        if(Enemies.GetComponent<EnemyManager>().Enemies.Count==0)
        {
            State = gameState.GameClear;
        }

        if(GameObject.FindWithTag("Player")==null)
        {
            State = gameState.GameOver;
        }


        //コマンドウィンドウの表示可否
        if(isRunning())
        {
            commandwin.SetActive(false);
        }
        else if(State==gameState.Command)
        {
            commandwin.SetActive(true);
        }


        //敵デバッグウィンドウの表示
        if(Input.GetKeyDown(KeyCode.Alpha0))
        {
            enemyDebugWindows.SetActive(!enemyDebugWindows.activeSelf);
        }
    }

    public async void runAll()
    {
        State = gameState.Run;
        UniTask runPlayer=PlayerObject.GetComponent<Character>().run();
        UniTask runEnemies=Enemies.GetComponent<EnemyManager>().runAllEnemies();

        await UniTask.WhenAll(runPlayer, runEnemies);
        
        State = gameState.Command;
        Enemies.GetComponent<EnemyManager>().pushCommandAllEnemies();
        BattleManager.Instance.step = 0;
        turn++;
        Debug.Log($"---ターン{turn}---");

    }

    public bool isRunning()
    {
        if(State==gameState.Run)
        {
            return true;
        }
        return false;
        
    }

    public void switchRun(bool enabled)
    {
        if(enabled)
        {
            State = gameState.Run;
        }
        else
        {
            State = gameState.Command;
        }
    }

}
