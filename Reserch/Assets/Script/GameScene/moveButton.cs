using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveButton : MonoBehaviour
{
    public GameObject playerObject;   //プレイヤーオブジェクト
    [SerializeField] EnemyManager enemyManager;
    private CommandList playerList;

    public AudioClip CommandSelectSound;
    public AudioClip RunSelectSound;
    AudioSource audioSource;

    [SerializeField]Animator centerTextAnim;


    // Start is called before the first frame update
    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        playerList = playerObject.GetComponent<CommandList>();

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpButtonOnClick()
    {
        // Debug.Log("Up押した");
        audioSource.PlayOneShot(CommandSelectSound);
        playerList.Add(new Up(playerObject));
    }

    public void LeftButtonOnClick()
    {
        // Debug.Log("Left押した");
        audioSource.PlayOneShot(CommandSelectSound);
        playerList.Add(new Left(playerObject));
    }

    public void RIghtButtonOnClick()
    {
        // Debug.Log("Right押した");
        audioSource.PlayOneShot(CommandSelectSound);
        playerList.Add(new Right(playerObject));
    }

    public void DownButtonOnClick()
    {
        //Debug.Log("Down押した");
        
        audioSource.PlayOneShot(CommandSelectSound);
        playerList.Add(new Down(playerObject));
    }

    public void putCubeButtononClick()
    {
        audioSource.PlayOneShot(CommandSelectSound);
        playerList.Add(new putCube(playerObject));
    }

    public void RunButtonOnClick()
    {
        GameManager.instance.ProgrammingTimes.Add(GameManager.instance.ProgrammingTime);
        GameManager.instance.ProgrammingTime = 0;

        GameManager.instance.switchRun(true);
        audioSource.PlayOneShot(RunSelectSound);

        //GameManager.instance.runAll();
        centerTextAnim.SetTrigger("Start");
    }

    public void DeleteButtonOnClick()
    {
        playerList.removeTail();
    }

    public void StayButtonOnClick()
    {
        audioSource.PlayOneShot(CommandSelectSound);
        playerList.Add(new stay(playerObject));
    }

    public void AreaStealButtonOnClick()
    {
        audioSource.PlayOneShot(CommandSelectSound);
        playerList.Add(new AreaSteal(playerObject));
    }

    public void SwordButtonOnClick()
    {
        playerList.Add(new Sword(playerObject));
    }

    public void CannonButtonOnClick()
    {
        playerList.Add(new Cannon(playerObject));
    }

    public void BombButtonOnClick()
    {
        playerList.Add(new Bomb(playerObject));
    }

    public void windButtonOnClikc()
    {
        playerList.Add(new Wind(playerObject));
    }

    public void IFButton()
    {
        playerList.Add(new If(playerObject, playerList.Count));
    }

    public void EndButton()
    {
        playerList.Add(new End(playerObject));
    }
}
