using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using UnityEngine.UI;

public class test : MonoBehaviour
{

    [SerializeField] GameObject DeckContentObj;
    GameObject oriBtn;

    void Start()
    {
        oriBtn = Resources.Load("btn") as GameObject;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onClick()
    {
        GameObject clobtn=Instantiate(oriBtn);
        clobtn.transform.parent = DeckContentObj.transform;
        clobtn.transform.localScale = new Vector3(1, 1, 1);
    }

}
