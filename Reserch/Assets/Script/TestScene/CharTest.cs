using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class CharTest : MonoBehaviour
{
    [SerializeField]BMTest BM;
    [SerializeField]int inputNum;
    public bool flag;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            testMethod();
        }

        if(Input.GetKeyDown(KeyCode.D))
        {
            flag = true;
        }

    }

    public async void testMethod()
    {
        flag = false;
        //Debug.Log($"{this.gameObject.name}=>送ります");
        BM.list.Add(new DateTest(this.gameObject,inputNum));

        await UniTask.WaitUntil(() => flag); //flagがtrueになるまで待つ

        Debug.Log($"{this.gameObject.name}=>実行");

    }
}
