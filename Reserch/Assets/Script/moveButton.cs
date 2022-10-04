using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveButton : MonoBehaviour
{
    public GameObject player;   //プレイヤーオブジェクト
    private playerMove playerScript;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<playerMove>();
    }

    public void UpButtonOnClick()
    {
        // Debug.Log("Up押した");

        playerScript.commandList.add(new Up(playerScript.charTag));
    }

    public void LeftButtonOnClick()
    {
        // Debug.Log("Left押した");
        playerScript.commandList.add(new Left(playerScript.charTag));
    }

    public void RIghtButtonOnClick()
    {
        // Debug.Log("Right押した");
        playerScript.commandList.add(new Right(playerScript.charTag));
    }

    public void DownButtonOnClick()
    {
        //Debug.Log("Down押した");
        playerScript.commandList.add(new Down(playerScript.charTag));
    }

    public void RunButtonOnClick()
    {
        GameManager.instance.switchRun(true);
    }

    public void DeleteButtonOnClick()
    {
        playerScript.commandList.removeTail();
    }
}
