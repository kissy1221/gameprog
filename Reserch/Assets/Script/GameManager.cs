using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Const;

public class GameManager : MonoBehaviour
{
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
    GameObject EnemyObject;


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
        EnemyObject = GameObject.FindGameObjectWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        if(isfinishCommand() && State==gameState.Run)
        {
            State = gameState.Command;

            Enemies.GetComponent<EnemyManager>().pushCommandAllEnemies();
        }

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
    }

    public bool isfinishCommand()
    {
        Character character;

        character = PlayerObject.GetComponent<Character>();
        if(character.commandStatus!=Character.CommandState.FINISH)
        {
            return false;
        }

        foreach(GameObject enemy in Enemies.GetComponent<EnemyManager>().Enemies)
        {
            character = enemy.GetComponent<Character>();

            if (character.commandStatus != Character.CommandState.FINISH)
            {
                return false;
            }
        }

        return true;

    }

    public void runAll()
    {
        State = gameState.Run;
        PlayerObject.GetComponent<Character>().run();
        Enemies.GetComponent<EnemyManager>().runAllEnemies();
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
