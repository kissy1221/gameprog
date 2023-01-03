using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveButton : MonoBehaviour
{
    public GameObject playerObject;   //プレイヤーオブジェクト
    private CommandList playerList;

    public AudioClip CommandSelectSound;
    public AudioClip RunSelectSound;
    AudioSource audioSource;


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
        audioSource.PlayOneShot(RunSelectSound);
        Debug.Log("Run!");
        GameObject.Find("CenterText").GetComponent<BattleStart>().anim.SetTrigger("Start");
        GameManager.instance.commandwin.SetActive(false);
        //GameManager.instance.switchRun(true);
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

    public void MineButtonOnClick()
    {
        playerList.Add(new Mine(playerObject));
    }
}
