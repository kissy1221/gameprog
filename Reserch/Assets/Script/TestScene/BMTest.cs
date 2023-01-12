using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class BMTest : MonoBehaviour
{

    public List<DateTest> list = new List<DateTest>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(list.Count>=4)
        {
            print();
            sort();
            print();

            foreach(DateTest test in list)
            {
                test.obj.GetComponent<CharTest>().flag = true;
            }

            list.Clear();
        }
    }

    //”š‚ª¬‚³‚¢‡‚É•À‚×‚é
    void sort()
    {
        DateTest temp;
        int minIndex;

        for(int i=0;i<list.Count-1;i++)
        {
            minIndex = i;

            for(int j=i+1;j<list.Count;j++)
            {
                if (list[j].num < list[minIndex].num)
                {
                    minIndex = j;
                }
            }

            temp = list[i];
            list[i] = list[minIndex];
            list[minIndex] = temp;
        }
    }

    void print()
    {
        string str="";
        foreach (DateTest com in list)
        {
            str += com.obj.name + "=>";
        }
        Debug.Log(str);
    }
}
