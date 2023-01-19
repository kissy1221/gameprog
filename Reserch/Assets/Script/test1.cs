using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;

public class test1 : MonoBehaviour
{
    private CancellationTokenSource cts;
    private CancellationTokenSource cts2;
    private CancellationTokenSource cts3;
    List<UniTask> array = new List<UniTask>();
    async void Start()
    {

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            RunAsync().Forget();
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log("�L�����Z��");

            cts?.Cancel();
            cts = null;
        }
    }

    async UniTaskVoid RunAsync()
    {
        cts = new CancellationTokenSource();
        cts2 = new CancellationTokenSource();
        cts3 = new CancellationTokenSource();
        UniTask task1 = WaitSec(3,cts.Token);
        UniTask task2 = WaitSec(3,cts.Token);
        UniTask task3 = WaitSec(4,cts.Token);
        try
        {
            Debug.Log("Start UniTask!");
            await UniTask.WhenAll(
                task1, task2, task3
                );
            Debug.Log("Complete All UniTask!");
        }
        finally
        {
            Debug.Log("Finally");
        }

    }

    // �w�肵���b���ҋ@����^�X�N  k
    async UniTask WaitSec(int sec)
    {
        Debug.Log($"{sec}�b�J�n���܂��B");
        await UniTask.Delay(sec*1000);
        Debug.Log($"Complete : {sec}�b�ҋ@����UniTask");
    }

    async UniTask WaitSec(int sec,CancellationToken token=default)
    {
        Debug.Log($"{sec}�b�J�n���܂��B");
        await UniTask.Delay
            (
                sec * 1000,
                cancellationToken: token
            );
        Debug.Log($"Complete : {sec}�b�ҋ@����UniTask");
    }
}
