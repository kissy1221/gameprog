using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;

    //true=>コマンド動作中 , false=>コマンド画面
    private bool running = false;
    

    private bool EnemyFinishReq = false;
    private bool PlayerFinishReq = false;

    public void setFinishReq(string charTag,bool Enable)
    {
        if (charTag == "Enemy")
            EnemyFinishReq = enabled;
        else
            PlayerFinishReq = enabled;
    }


    [SerializeField] private GameObject commandwin;
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

    }

    // Update is called once per frame
    void Update()
    {
        if(EnemyFinishReq && PlayerFinishReq)
        {
            switchRun(false);
            EnemyFinishReq = false;
            PlayerFinishReq = false;
            commandwin.SetActive(true);

            GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>().pushCommandListAtRondom();
        }

        if (isRunning())
            commandwin.SetActive(false);

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
