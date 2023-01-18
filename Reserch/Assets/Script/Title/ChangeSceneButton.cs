using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneButton : MonoBehaviour
{
    [SerializeField] GameObject OptionMenu;
    
    public void OnClickGameStart()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void onClickCreateDeck()
    {
        SceneManager.LoadScene("buildDeck");
    }

    public void onClickOpution()
    {
        OptionMenu.SetActive(true);
        OptionMenu.GetComponent<OptionManager>().reflectOptionData();
    }    

    public void onClickExit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;//�Q�[���v���C�I��
        #else
            Application.Quit();//�Q�[���v���C�I��
        #endif
    }
}
