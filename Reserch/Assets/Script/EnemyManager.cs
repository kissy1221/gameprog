using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemyManager : MonoBehaviour
{

    public List<GameObject> Enemies = new List<GameObject>();
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
        Enemies = GameObject.FindGameObjectsWithTag("Enemy").ToList();

        //全キャラクターに実行を伝える
        if (canCall())
        {
            Call();
        }

    }

    void Call()
    {
        Player.GetComponent<Character>().CommandAllow = true;

        foreach (GameObject Enemy in Enemies)
        {
            Enemy.GetComponent<Character>().CommandAllow = true;
        }
    }

    bool canCall()
    {
        Character player = Player.GetComponent<Character>();

        if (player.commandStatus == Character.CommandState.START || player.commandStatus == Character.CommandState.EXCUTE)
        {
            return false;
        }

        foreach (GameObject Enemy in Enemies)
        {
            Character enemy = Enemy.GetComponent<Character>();

            if (enemy.commandStatus == Character.CommandState.START || enemy.commandStatus == Character.CommandState.EXCUTE)
            {
                return false;
            }

        }

        return true;

    }

    public void runAllEnemies()
    {
        foreach (GameObject Enemy in Enemies)
        {
            Enemy.GetComponent<Enemy>().run();
        }
    }

    public void pushCommandAllEnemies()
    {
        foreach (GameObject Enemy in Enemies)
        {
            Enemy.GetComponent<Enemy>().pushCommandListAtRondom();
        }
    }
}
