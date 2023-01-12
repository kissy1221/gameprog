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
        //�ۑ����ꂽ�I�v�V�����f�[�^�����邩���ׂ�
        if (PlayerPrefs.HasKey("EnemyNum") && PlayerPrefs.HasKey("Blind"))
        {
            Debug.Log("�Z�[�u�f�[�^�͂���܂�");
            Debug.Log($"�G�̐�:{PlayerPrefs.GetInt("EnemyNum")},�Öك��[�h{Convert.ToBoolean(PlayerPrefs.GetInt("Blind"))}");

            EnemyNumDropDown.value = PlayerPrefs.GetInt("EnemyNum") - 1;
            isBlind.isOn = Convert.ToBoolean(PlayerPrefs.GetInt("Blind"));
        }
        else
        {
            Debug.Log("����܂���");

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //����{�^��
    public void onClickExitButton()
    {
        this.gameObject.SetActive(false);
    }
    
    //����{�^��
    public void onClickDone()
    {
        Debug.Log($"�G�̐�:{EnemyNumDropDown.value + 1},�Öك��[�h{isBlind.isOn}");

        PlayerPrefs.SetInt("EnemyNum", EnemyNumDropDown.value + 1);
        PlayerPrefs.SetInt("Blind",Convert.ToInt32(isBlind.isOn));

        PlayerPrefs.Save();
    }
}
