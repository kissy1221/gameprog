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

        playerScript.commandList.push("up");
    }

    public void LeftButtonOnClick()
    {
       // Debug.Log("Left������");
        playerScript.commandList.push("left");
    }

    public void RIghtButtonOnClick()
    {
       // Debug.Log("Right������");
        playerScript.commandList.push("right");
    }

    public void DownButtonOnClick()
    {
        //Debug.Log("Down������");
        playerScript.commandList.push("down");
    }

    public void RunButtonOnClick()
    {
        playerScript.commandList.switchRun(true);
    }
}
