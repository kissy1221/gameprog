using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class ExplosionEffect : MonoBehaviour
{
    // Start is called before the first frame update
    async void Start()
    {
        await UniTask.Delay(1500);
        GameObject.Destroy(this.gameObject);
    }
}
