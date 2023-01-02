using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveButton : MonoBehaviour
{
    public GameObject playerObject;   //プレイヤーオブジェクト
    private Player player;

    public AudioClip CommandSelectSound;
    public AudioClip RunSelectSound;
    AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        player = playerObject.GetComponent<Player>();

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
        player.commandList.add(new Up(playerObject));
    }

    public void LeftButtonOnClick()
    {
        // Debug.Log("Left押した");
        audioSource.PlayOneShot(CommandSelectSound);
        player.commandList.add(new Left(playerObject));
    }

    public void RIghtButtonOnClick()
    {
        // Debug.Log("Right押した");
        audioSource.PlayOneShot(CommandSelectSound);
        player.commandList.add(new Right(playerObject));
    }

    public void DownButtonOnClick()
    {
        //Debug.Log("Down押した");
        
        audioSource.PlayOneShot(CommandSelectSound);
        player.commandList.add(new Down(playerObject));
    }

    public void putCubeButtononClick()
    {
        audioSource.PlayOneShot(CommandSelectSound);
        player.commandList.add(new putCube(playerObject));
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
        player.commandList.removeTail();
    }

    public void StayButtonOnClick()
    {
        audioSource.PlayOneShot(CommandSelectSound);
        player.commandList.add(new stay(playerObject));
    }

    public void AreaStealButtonOnClick()
    {
        audioSource.PlayOneShot(CommandSelectSound);
        player.commandList.add(new AreaSteal(playerObject));
    }

    public void SwordButtonOnClick()
    {
        player.commandList.add(new Sword(playerObject));
    }

    public void CannonButtonOnClick()
    {
        player.commandList.add(new Cannon(playerObject));
    }

    public void MineButtonOnClick()
    {
        player.commandList.add(new Mine(playerObject));
    }
}
