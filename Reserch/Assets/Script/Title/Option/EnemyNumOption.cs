using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyNumOption : MonoBehaviour
{
    [SerializeField] public Dropdown EnemyNumDropDown;

    //
    public int getEnemyNum()
    {
        return EnemyNumDropDown.value + 1;
    }
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
