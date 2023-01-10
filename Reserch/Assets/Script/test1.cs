using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class test1 : MonoBehaviour
{
    List<UniTask> array = new List<UniTask>();
    async void Start()
    {
        UniTask task1 = WaitSec(1);
        UniTask task2 = WaitSec(3);
        UniTask task3 = WaitSec(4);

        Debug.Log("Start UniTask!");
        await UniTask.WhenAll(task1,task2,task3);
        Debug.Log("Complete All UniTask!");
    }

    // 指定した秒数待機するタスク  
    async UniTask WaitSec(int sec)
    {
        Debug.Log($"{sec}秒開始します。");
        await UniTask.Delay(sec*1000);
        Debug.Log($"Complete : {sec}秒待機したUniTask");
    }
}
