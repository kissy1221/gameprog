using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//コンポーネントを付与することで敵コマンドが一部隠れる
public class Blind : MonoBehaviour
{

    List<int> blackoutList = new List<int>();
    Sprite BlackOutImage;

    GameObject EnemyCommandIcon;

    // Start is called before the first frame update
    void Start()
    {

        EnemyCommandIcon = GameObject.Find("EnemyCommandIcon");
        BlackOutImage= Resources.Load<Sprite>("Images/BlindNoise");


        int num = Random.Range(3, 5);

        for(int i=0;i<=num;i++)
        {
            int BlindNum;

            do
            {
                BlindNum = Random.Range(0, 9); //見えなくするコマンドリスト配列の場所

            } while (blackoutList.Contains(BlindNum));

            blackoutList.Add(BlindNum);

        }
    }

    // Update is called once per frame
    void Update()
    {
        PrintNoiseIndex();

        
        foreach(int BlackOutNum in blackoutList)
        {
            int num = BlackOutNum + 1;
            string str = "Command"+num;
            GameObject target = EnemyCommandIcon.transform.Find(str).gameObject;

            target.GetComponent<Image>().sprite = BlackOutImage;
        }
        

    }

    void PrintNoiseIndex()
    {
        string str = null;
        foreach (int num in blackoutList)
        {
            str += num + ",";
        }

        Debug.Log("見えなくする場所:" + str);
    }
}
