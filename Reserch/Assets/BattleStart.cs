using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleStart : MonoBehaviour
{
    public Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            anim.SetTrigger("Start");
        }
        
    }

    public void finishAnim()
    {
        GameManager.instance.switchRun(true);
    }


}
