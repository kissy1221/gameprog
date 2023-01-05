using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class debugScript : MonoBehaviour
{

    enum COIN
    {
        omote=1,
        ura=-1
    }

    COIN coin = COIN.omote;


    // Start is called before the first frame update
    void Start()
    {
        int a=1;
        COIN coin = (COIN)(a*-1);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
