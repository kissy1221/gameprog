using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;

    //true=>�R�}���h���쒆 , false=>�R�}���h���
    private bool running = false;
    

    //�R�}���h���I��������
    private bool EnemyFinishReq = false;
    private bool PlayerFinishReq = false;

    //�P�̃R�}���h���I��������
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

    public void setMoveReq(Character character,bool Enabled)
    {

        if(character.GetType()==typeof(Player))
        {
            PlayerMoveReq = Enabled;
        }
        else
        {
            EnemyMoveReq = Enabled;
        }
    }

    public bool getMove(string charTag)
    {
        if(charTag=="Player")
        {
            return PlayerMoveReq;
        }
        else
        {
            return EnemyMoveReq;
        }
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
            Debug.Log("�o���I���̃��N�G�X�g�����܂���");

            switchRun(false);
            EnemyFinishReq = false;
            PlayerFinishReq = false;

            setMoveReq(true);

            commandwin.SetActive(true);

            GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>().pushCommandListAtRondom();
        }

        if (isRunning())
            commandwin.SetActive(false);

        if ((PlayerMoveReq && EnemyMoveReq) ||EnemyFinishReq || PlayerFinishReq )
            setMoveReq(false);


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
