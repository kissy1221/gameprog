using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//付与したキャラクターのコマンドリストを非表示させる
public class BlindEnemy : MonoBehaviour
{

    CommandList _commandList;
    Sprite BlackOutImage;
    GameObject commandListUI;


    // Start is called before the first frame update
    void Start()
    {
        _commandList = GetComponent<CommandList>();
        commandListUI = _commandList.commandListUI;
        BlackOutImage = Resources.Load<Sprite>("Images/BlindNoise");
    }

    // Update is called once per frame
    void Update()
    {

        foreach (Transform child in commandListUI.transform)
        {
            Image img = child.gameObject.GetComponent<Image>();
            img.sprite = BlackOutImage;
        }
    }
}
