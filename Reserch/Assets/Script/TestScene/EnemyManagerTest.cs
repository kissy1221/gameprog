using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyManagerTest : MonoBehaviour
{

    List<GameObject> Enemies = new List<GameObject>();
    GameObject Player;


    // Start is called before the first frame update
    void Start()
    {
        Enemies = GameObject.FindGameObjectsWithTag("Enemy").ToList();
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

        //全キャラクターに実行を伝える
        if(canCall())
        {
            Call();
        }

    }


    void Call()
    {
        Player.GetComponent<CharacterTest>().Allow = true;

        foreach(GameObject Enemy in Enemies)
        {
            Enemy.GetComponent<CharacterTest>().Allow = true;
        }
    }

    bool canCall()
    {
        CharacterTest player=Player.GetComponent<CharacterTest>();

        if(player.status==CharacterTest.State.START || player.status == CharacterTest.State.EXCUTE)
        {
            return false;
        }

        foreach (GameObject Enemy in Enemies)
        {
            CharacterTest enemy = Enemy.GetComponent<CharacterTest>();

            if (enemy.status == CharacterTest.State.START || enemy.status == CharacterTest.State.EXCUTE)
            {
                return false;
            }

        }

        return true;

    }
}
