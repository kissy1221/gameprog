using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class test1 : MonoBehaviour
{
    List<UniTask> array = new List<UniTask>();
    async void Start()
    {


        Debug.Log("Start UniTask!");
        await UniTask.WhenAll(WaitSec(1),WaitSec(2));
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
