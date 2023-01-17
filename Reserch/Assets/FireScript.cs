using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript : MonoBehaviour
{
    Rigidbody2D rg2d;
    [SerializeField]float power;
    // Start is called before the first frame update
    void Start()
    {
        rg2d = GetComponent<Rigidbody2D>();
        Vector3 force = new Vector3(power, 0, 0);
        rg2d.AddForce(force);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
