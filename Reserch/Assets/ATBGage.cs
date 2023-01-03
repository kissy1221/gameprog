using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ATBGage : MonoBehaviour
{
    private Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();

        slider.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.State==GameManager.gameState.Command)
        {
            slider.value += Time.deltaTime / 30;
        }
        

        if(slider.value==1)
        {
            slider.value = 0;
            GameManager.instance.switchRun(true);
        }


    }
}
