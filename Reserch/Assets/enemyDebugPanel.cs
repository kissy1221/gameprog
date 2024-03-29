using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDebugPanel : MonoBehaviour
{
    public GameObject selectEnemyObject = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onClickDelete()
    {
        selectEnemyObject.GetComponent<CommandList>().removeTail();
    }

    public void UpButtonOnClick()
    {
        // Debug.Log("Up押した");
        selectEnemyObject.GetComponent<CommandList>().Add(new Up(selectEnemyObject));
    }

    public void LeftButtonOnClick()
    {
        // Debug.Log("Left押した");
        selectEnemyObject.GetComponent<CommandList>().Add(new Left(selectEnemyObject));
    }

    public void RIghtButtonOnClick()
    {
        // Debug.Log("Right押した");
        selectEnemyObject.GetComponent<CommandList>().Add(new Right(selectEnemyObject));
    }

    public void DownButtonOnClick()
    {
        //Debug.Log("Down押した");

        selectEnemyObject.GetComponent<CommandList>().Add(new Down(selectEnemyObject));
    }

    public void SwordButtonOnClick()
    {
        //Debug.Log("Down押した");

        selectEnemyObject.GetComponent<CommandList>().Add(new WarpSword(selectEnemyObject));
    }


}
