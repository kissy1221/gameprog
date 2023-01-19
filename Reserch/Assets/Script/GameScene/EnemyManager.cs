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

    [SerializeField]int EnemyTotalHP;

    bool isBlindMode;
    int BlindNum = 0; //初期値として０を代入



    // Start is called before the first frame update
    void Start()
    {
        //
        if(PlayerPrefs.HasKey("EnemyNum"))
        {
            EnemyNum = PlayerPrefs.GetInt("EnemyNum");
        }

        if(PlayerPrefs.HasKey("Blind"))
        {
            //ブラインドモードだったら
            if(Convert.ToBoolean(PlayerPrefs.GetInt("Blind")))
            {
                BlindNum = PlayerPrefs.GetInt("BlindNum");
            }
        }


        Enemies = GameObject.FindGameObjectsWithTag("Enemy").ToList();
        Player = GameObject.FindGameObjectWithTag("Player");

        addEnemy(EnemyNum);

        Enemies = GameObject.FindGameObjectsWithTag("Enemy").ToList();//敵状況更新

        //Debug.Log("暗黙人数=" + BlindNum);
    }

    // Update is called once per frame
    void Update()
    {
        
        Enemies = GameObject.FindGameObjectsWithTag("Enemy").ToList();//敵状況更新
        
    }


    void addEnemy(int num)
    {

        if(num<=0 || 3<num)
        {
            throw new ArgumentOutOfRangeException("敵の数を１～３の間で設定してください");
        }

        GameObject samuraiObj = Resources.Load(Const.CO.PATH.PREFAB + "Enemy/Samurai") as GameObject;
        GameObject wizardObj = Resources.Load(Const.CO.PATH.PREFAB + "Enemy/Wizard") as GameObject;
        GameObject WarriorObj= Resources.Load(Const.CO.PATH.PREFAB + "Enemy/Warrior") as GameObject;

        for (int i=0;i<num;i++)
        {
            int x, y;

            GameObject enemy;

            switch(i)
            {
                case 0:
                    x = CO.INIT_POS.ENEMY1.X;
                    y= CO.INIT_POS.ENEMY1.Y;
                    enemy = samuraiObj;
                    break;
                case 1:
                    x= CO.INIT_POS.ENEMY2.X;
                    y= CO.INIT_POS.ENEMY2.Y;
                    enemy = wizardObj;
                    break;
                case 2:
                    x=CO.INIT_POS.ENEMY3.X;
                    y= CO.INIT_POS.ENEMY3.Y;
                    enemy = WarriorObj;
                    break;
                default:
                    x = 0;
                    y = 0;
                    enemy = WarriorObj;
                    break;
            }
            GameObject enemycopy = Instantiate(enemy, Vector3.zero, Quaternion.identity, this.transform);
            Enemy enemyScript = enemycopy.GetComponent<Enemy>();
            enemyScript.setHP(EnemyTotalHP / num); //HPセット
            enemycopy.name = $"Enemy{i + 1}";
            if(BlindNum>0)
            {
                enemycopy.AddComponent<BlindEnemy>();
                BlindNum--;
            }
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
