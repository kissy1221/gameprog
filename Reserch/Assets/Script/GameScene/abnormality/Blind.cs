using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//�R���|�[�l���g��t�^���邱�ƂœG�R�}���h���ꕔ�B���
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
                BlindNum = Random.Range(0, 9); //�����Ȃ�����R�}���h���X�g�z��̏ꏊ

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

        Debug.Log("�����Ȃ�����ꏊ:" + str);
    }
}
