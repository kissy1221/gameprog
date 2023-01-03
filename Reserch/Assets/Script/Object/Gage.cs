using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gage : MonoBehaviour
{
    Slider slider;
    private int time;

    bool flag=false;

    public void setTime(int value)
    {
        time = value;
        flag = true;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        slider=GetComponent<Slider>();
        slider.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (flag)
        {
            slider.value += Time.deltaTime / time;
        }
        
        if(slider.value>=1)
        {
            flag = false;
            slider.value = 0;
        }
    }
}
