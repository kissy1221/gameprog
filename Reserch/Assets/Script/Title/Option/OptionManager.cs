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


    //����{�^��
    public void onClickExitButton()
    {
        this.gameObject.SetActive(false);
    }
    
    //����{�^��
    public void onClickDone()
    {
        Debug.Log($"�G�̐�:{EnemyNumOpt.getEnemyNum()},�Öك��[�h{blindOpt.isBlindOn},�Öِl��{blindOpt.getBlindNum()}");

        PlayerPrefs.SetInt("EnemyNum", EnemyNumOpt.getEnemyNum());
        PlayerPrefs.SetInt("Blind",Convert.ToInt32(blindOpt.isBlindOn));
        PlayerPrefs.SetInt("BlindNum", blindOpt.getBlindNum());

        PlayerPrefs.Save();
    }

    public void reflectOptionData()
    {
        //�ۑ����ꂽ�I�v�V�����f�[�^�����邩���ׂ�
        if (PlayerPrefs.HasKey("EnemyNum") && PlayerPrefs.HasKey("Blind"))
        {
            Debug.Log("�Z�[�u�f�[�^�͂���܂�");
            Debug.Log($"�G�̐�:{PlayerPrefs.GetInt("EnemyNum")},�Öك��[�h{Convert.ToBoolean(PlayerPrefs.GetInt("Blind"))}�Öِl��:{PlayerPrefs.GetInt("BlindNum")}");

            EnemyNumOpt.EnemyNumDropDown.value = PlayerPrefs.GetInt("EnemyNum") - 1;
            blindOpt.isBlindOn = Convert.ToBoolean(PlayerPrefs.GetInt("Blind"));
            blindOpt.setBlindNum(PlayerPrefs.GetInt("BlindNum"));
        }
        else
        {
            Debug.Log("����܂���");

        }
    }
}
