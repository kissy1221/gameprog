using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    GameObject ObjectOnFloor;//

    public enum floorColor
    {
        Red,
        Blue
    };

    [SerializeField] floorColor color;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public floorColor getColor()
    {
        return this.color;
    }
}
