using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System.Linq;
using Const;

public class EnemyManager : MonoBehaviour
{

    [HideInInspector]public List<GameObject> Enemies = new List<GameObject>();
    [SerializeField] int EnemyNum;
    GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        Enemies = GameObject.FindGameObjectsWithTag("Enemy").ToList();
        Player = GameObject.FindGameObjectWithTag("Player");

        addEnemy(EnemyNum);
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

    void addEnemy(int num)
    {
        GameObject enemy = Resources.Load(Const.CO.PATH.PREFAB + "Enemy/Samurai") as GameObject;

        for (int i=0;i<num;i++)
        {
            int x, y;

            switch(i)
            {
                case 0:
                    x = CO.INIT_POS.ENEMY1.X;
                    y= CO.INIT_POS.ENEMY1.Y;
                    break;
                case 1:
                    x= CO.INIT_POS.ENEMY2.X;
                    y= CO.INIT_POS.ENEMY2.Y;
                    break;
                case 2:
                    x=CO.INIT_POS.ENEMY3.X;
                    y= CO.INIT_POS.ENEMY3.Y;
                    break;
                default:
                    x = 0;
                    y = 0;
                    break;
            }

            GameObject enemycopy = Instantiate(enemy, Vector3.zero, Quaternion.identity, this.transform);
            Map.Instance.getFloor(x,y).putObject(enemycopy);

        }

    }
    
    void addEnemy()
    {
        GameObject enemy = Resources.Load(Const.CO.PATH.PREFAB + "Enemy/Samurai") as GameObject;
        GameObject enemycopy = Instantiate(enemy, Vector3.zero, Quaternion.identity, this.transform);
        Map.Instance.getFloor(CO.INIT_POS.ENEMY1.X, CO.INIT_POS.ENEMY1.Y).putObject(enemycopy);
    }

    public async UniTask runAllEnemies()
    {
        List<UniTask> runTask = new List<UniTask>();
        foreach (GameObject Enemy in Enemies)
        {
           UniTask task = Enemy.GetComponent<Enemy>().run();
           runTask.Add(task);
        }

        await UniTask.WhenAll(runTask);
    }

    public void pushCommandAllEnemies()
    {
        foreach (GameObject Enemy in Enemies)
        {
            Enemy.GetComponent<Enemy>().pushCommandListAtRondom();
        }
    }
}
