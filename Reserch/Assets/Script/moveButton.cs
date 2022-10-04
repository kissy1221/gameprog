using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveButton : MonoBehaviour
{
    public GameObject player;   //�v���C���[�I�u�W�F�N�g
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
        // Debug.Log("Up������");

        playerScript.commandList.add(new Up(playerScript.charTag));
    }

    public void LeftButtonOnClick()
    {
        // Debug.Log("Left������");
        playerScript.commandList.add(new Left(playerScript.charTag));
    }

    public void RIghtButtonOnClick()
    {
        // Debug.Log("Right������");
        playerScript.commandList.add(new Right(playerScript.charTag));
    }

    public void DownButtonOnClick()
    {
        //Debug.Log("Down������");
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
