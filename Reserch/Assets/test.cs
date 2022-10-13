using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    Transform obj;
    
    void Start()
    {
        obj = this.transform.GetComponent<Transform>();

        Debug.Log(transform.localPosition);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
