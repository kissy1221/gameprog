using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class OptionManager : MonoBehaviour
{
    [SerializeField] isBlindOption blindOpt;
    [SerializeField] EnemyNumOption EnemyNumOpt;

    // Start is called before the first frame update
    void Start()
    {
        reflectOptionData();
    }


    //閉じるボタン
    public void onClickExitButton()
    {
        this.gameObject.SetActive(false);
    }
    
    //決定ボタン
    public void onClickDone()
    {
        Debug.Log($"敵の数:{EnemyNumOpt.getEnemyNum()},暗黙モード{blindOpt.isBlindOn},暗黙人数{blindOpt.getBlindNum()}");

        PlayerPrefs.SetInt("EnemyNum", EnemyNumOpt.getEnemyNum());
        PlayerPrefs.SetInt("Blind",Convert.ToInt32(blindOpt.isBlindOn));
        PlayerPrefs.SetInt("BlindNum", blindOpt.getBlindNum());

        PlayerPrefs.Save();
    }

    public void reflectOptionData()
    {
        //保存されたオプションデータがあるか調べる
        if (PlayerPrefs.HasKey("EnemyNum") && PlayerPrefs.HasKey("Blind"))
        {
            Debug.Log("セーブデータはあります");
            Debug.Log($"敵の数:{PlayerPrefs.GetInt("EnemyNum")},暗黙モード{Convert.ToBoolean(PlayerPrefs.GetInt("Blind"))}暗黙人数:{PlayerPrefs.GetInt("BlindNum")}");

            EnemyNumOpt.EnemyNumDropDown.value = PlayerPrefs.GetInt("EnemyNum") - 1;
            blindOpt.isBlindOn = Convert.ToBoolean(PlayerPrefs.GetInt("Blind"));
            blindOpt.setBlindNum(PlayerPrefs.GetInt("BlindNum"));
        }
        else
        {
            Debug.Log("ありません");

        }
    }
}
