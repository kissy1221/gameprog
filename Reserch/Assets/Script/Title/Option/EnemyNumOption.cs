using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyNumOption : MonoBehaviour
{
    [SerializeField] public Dropdown EnemyNumDropDown;
    [SerializeField] public Dropdown BlindDropDown;

    //
    public int getEnemyNum()
    {
        return EnemyNumDropDown.value + 1;
    }

    public void changeNum()
    {
        BlindDropDown.ClearOptions();

        for(int i=0;i<getEnemyNum();i++)
        {
            BlindDropDown.options.Add(new Dropdown.OptionData { text = (i + 1).ToString() });
        }

        BlindDropDown.RefreshShownValue();
        BlindDropDown.value = 0;
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
