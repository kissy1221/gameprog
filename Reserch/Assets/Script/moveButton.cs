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
        player.commandList.add(new Up(player));
    }

    public void LeftButtonOnClick()
    {
        // Debug.Log("Left押した");
        audioSource.PlayOneShot(CommandSelectSound);
        player.commandList.add(new Left(player));
    }

    public void RIghtButtonOnClick()
    {
        // Debug.Log("Right押した");
        audioSource.PlayOneShot(CommandSelectSound);
        player.commandList.add(new Right(player));
    }

    public void DownButtonOnClick()
    {
        //Debug.Log("Down押した");
        
        audioSource.PlayOneShot(CommandSelectSound);
        player.commandList.add(new Down(player));
    }

    public void putCubeButtononClick()
    {
        audioSource.PlayOneShot(CommandSelectSound);
        player.commandList.add(new putCube(player));
    }

    public void RunButtonOnClick()
    {
        audioSource.PlayOneShot(RunSelectSound);
        Debug.Log("Run!");
        GameManager.instance.switchRun(true);
    }

    public void DeleteButtonOnClick()
    {
        player.commandList.removeTail();
    }

    public void StayButtonOnClick()
    {
        audioSource.PlayOneShot(CommandSelectSound);
        player.commandList.add(new stay(player));
    }

    public void AreaStealButtonOnClick()
    {
        audioSource.PlayOneShot(CommandSelectSound);
        player.commandList.add(new AreaSteal(player));
    }
}
