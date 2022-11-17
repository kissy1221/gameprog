using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class test : MonoBehaviour
{

    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    async UniTask Task1()
    {
        await UniTask.Delay(1 * 1000);

        Debug.Log("Task1èIóπ");
    }

}
