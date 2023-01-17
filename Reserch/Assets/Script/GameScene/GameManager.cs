using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;
using Const;

public class GameManager : MonoBehaviour
{
    //�������ʗp
    public List<float> ProgrammingTimes = new List<float>();
    public float ProgrammingTime { get; set; } = 0;

    int turn=1;

    [SerializeField]GameObject enemyDebugWindows;
    [SerializeField] Text StartText;

    public enum gameState
    {
        Run,    //Run��
        Command, //�R�}���h�I��
        GameClear,//�Q�[���N���A����
        GameOver//�Q�[���I�[�o�[�ɂȂ���
    }

    public gameState State=gameState.Command;

    public static GameManager instance = null;

    GameObject PlayerObject;
    [SerializeField]GameObject Enemies;


    [SerializeField] public GameObject commandwin;
    
    [System.Serializable]
    public class Result
    {
       public  GameObject window;
        public Text ResultText;
       public  Text TurnText;
       public Text TimeText;
    }

    public Result m_Result;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(this.gameObject);
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

        if (State == gameState.Command)
        {
            ProgrammingTime += Time.deltaTime;
        }

        if (Enemies.GetComponent<EnemyManager>().Enemies.Count==0)
        {
            State = gameState.GameClear;
            m_Result.ResultText.text = "����";
            m_Result.TurnText.text = ProgrammingTimes.Count.ToString();
            m_Result.TimeText.text = calcAvg(ProgrammingTimes).ToString("0.00");
            m_Result.window.SetActive(true);
            
        }

        if(GameObject.FindWithTag("Player")==null)
        {
            State = gameState.GameOver;
            m_Result.ResultText.text = "�s�k";
            m_Result.TurnText.text = turn.ToString();
            m_Result.TimeText.text = calcAvg(ProgrammingTimes).ToString("0.00");
            m_Result.window.SetActive(true);
        }


        //�R�}���h�E�B���h�E�̕\����
        if(isRunning())
        {
            commandwin.SetActive(false);
        }
        else if(State==gameState.Command)
        {
            commandwin.SetActive(true);
        }


        //�G�f�o�b�O�E�B���h�E�̕\��
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
        Debug.Log($"---�^�[��{turn}---");

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

    float calcAvg(List<float> data)
    {
        float sum=0;

        for (int i = 0; i < data.Count; i++)
        {
            sum += data[i];
        }

        return sum / data.Count;

    }

}
