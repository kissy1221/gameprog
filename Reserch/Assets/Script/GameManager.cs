using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Const;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;
    GameObject PlayerObject;
    GameObject EnemyObject;
    //true=>�R�}���h���쒆 , false=>�R�}���h���
    private bool running = false;
    

    //�R�}���h���I��������
    private bool EnemyFinishReq = false;
    private bool PlayerFinishReq = false;

    //�P�̃R�}���h���I�������� true���R�}���h���s false ���R�}���h���s���Ă��Ȃ�
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
            Debug.Log("�o���I���̃��N�G�X�g�����܂���");

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
                Debug.Log("�G�̃R�}���h�I��");
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
            

        //Debug.Log("�G���N�G�X�g"+EnemyMoveReq);
        //Debug.Log("�v���C���[���N�G�X�g" + PlayerMoveReq);


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
