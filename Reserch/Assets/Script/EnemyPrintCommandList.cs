using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPrintCommandList : CommandIcon
{
    // Start is called before the first frame update
    void Start()
    {
        characterScript = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Character>();
    }
}
