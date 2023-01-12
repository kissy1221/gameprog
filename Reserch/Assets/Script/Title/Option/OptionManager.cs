using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class OptionManager : MonoBehaviour
{
    [SerializeField]Dropdown EnemyNumDropDown;
    [SerializeField] Toggle isBlind;

    // Start is called before the first frame update
    void Start()
    {
        //保存されたオプションデータがあるか調べる
        if (PlayerPrefs.HasKey("EnemyNum") && PlayerPrefs.HasKey("Blind"))
        {
            Debug.Log("セーブデータはあります");
            Debug.Log($"敵の数:{PlayerPrefs.GetInt("EnemyNum")},暗黙モード{Convert.ToBoolean(PlayerPrefs.GetInt("Blind"))}");

            EnemyNumDropDown.value = PlayerPrefs.GetInt("EnemyNum") - 1;
            isBlind.isOn = Convert.ToBoolean(PlayerPrefs.GetInt("Blind"));
        }
        else
        {
            Debug.Log("ありません");

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //閉じるボタン
    public void onClickExitButton()
    {
        this.gameObject.SetActive(false);
    }
    
    //決定ボタン
    public void onClickDone()
    {
        Debug.Log($"敵の数:{EnemyNumDropDown.value + 1},暗黙モード{isBlind.isOn}");

        PlayerPrefs.SetInt("EnemyNum", EnemyNumDropDown.value + 1);
        PlayerPrefs.SetInt("Blind",Convert.ToInt32(isBlind.isOn));

        PlayerPrefs.Save();
    }
}
