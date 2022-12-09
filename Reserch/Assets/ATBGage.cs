using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ATBGage : MonoBehaviour
{
    private Slider slider;
    float time=0;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();

        slider.value = 0;
    }

    // Update is called once per frame
    void Update()
    {

        slider.value+=Time.deltaTime/30;

        if(slider.value==1)
        {
            slider.value = 0;
        }
    }
}
