using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System.Linq;
using Const;
using System;

public class EnemyManager : SingletonMonoBehaviour<EnemyManager>
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

        Enemies = GameObject.FindGameObjectsWithTag("Enemy").ToList();//ìGèÛãµçXêV
    }

    // Update is called once per frame
    void Update()
    {
        
        Enemies = GameObject.FindGameObjectsWithTag("Enemy").ToList();//ìGèÛãµçXêV
        
    }


    void addEnemy(int num)
    {

        if(num<=0 || 3<num)
        {
            throw new ArgumentOutOfRangeException("ìGÇÃêîÇÇPÅ`ÇRÇÃä‘Ç≈ê›íËÇµÇƒÇ≠ÇæÇ≥Ç¢");
        }

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
            enemycopy.name = $"Enemy{i + 1}";
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
