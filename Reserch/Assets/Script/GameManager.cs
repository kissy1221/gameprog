using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Const;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;
    GameObject PlayerObject;
    GameObject EnemyObject;
    //true=>コマンド動作中 , false=>コマンド画面
    private bool running = false;
    

    //コマンドが終了したか
    private bool EnemyFinishReq = false;
    private bool PlayerFinishReq = false;

    //１つのコマンドが終了したか true→コマンド実行 false →コマンド実行していない
    private bool EnemyMoveReq = true;
    private bool PlayerMoveReq = true;

    public void setFinishReq(Character character,bool Enable)
    {
        if(character.GetType()==typeof(Player))
        {
            PlayerFinishReq = Enable;
        }
        else
        {
            EnemyFinishReq = Enable;
        }
    }

    public void setMoveReq(bool Enabled)
    {
        EnemyMoveReq = Enabled;
        PlayerMoveReq = Enabled;
    }

    public void setMoveReq(GameObject character,bool Enabled)
    {

        if(character.tag=="Player")
        {
            PlayerMoveReq = Enabled;
        }
        else
        {
            EnemyMoveReq = Enabled;
        }
    }

    public bool getMove(GameObject character)
    {
        if(character.tag=="Player")
        {
            return PlayerMoveReq;
        }
        else
        {
            return EnemyMoveReq;
        }
    }


    [SerializeField] public GameObject commandwin;
    [SerializeField] private GameObject Player;


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
        if(EnemyFinishReq && PlayerFinishReq)
        {
            Debug.Log("双方終了のリクエストが来ました");

            switchRun(false);
            EnemyFinishReq = false;
            PlayerFinishReq = false;

            setMoveReq(true);

            commandwin.SetActive(true);

            GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>().pushCommandListAtRondom();
        }

        if (isRunning())
        {
            commandwin.SetActive(false);
        }
            

        if (PlayerMoveReq && EnemyMoveReq)
        {

            Debug.Log("PlayerMoveReq:" + PlayerFinishReq);
            Debug.Log("EnemyMoveReq:" + EnemyFinishReq);

            if (EnemyFinishReq && !PlayerFinishReq)
            {
                Debug.Log("敵のコマンド終了");
                setMoveReq(PlayerObject, false);
                PlayerObject.GetComponent<Character>().CommandAllow = true;
            }
            else if(PlayerFinishReq && !EnemyFinishReq)
            {
                setMoveReq(EnemyObject, false);
                EnemyObject.GetComponent<Character>().CommandAllow = true;
            }
            else
            {
                setMoveReq(false);
                PlayerObject.GetComponent<Character>().CommandAllow = true;
                EnemyObject.GetComponent<Character>().CommandAllow = true;
            }
            
        }
            

        //Debug.Log("敵リクエスト"+EnemyMoveReq);
        //Debug.Log("プレイヤーリクエスト" + PlayerMoveReq);


    }

    public bool isRunning()
    {
        return running;
    }

    public void switchRun(bool enabled)
    {
        running = enabled;
    }

}
