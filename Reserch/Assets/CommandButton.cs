using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommandButton : MonoBehaviour
{
    [SerializeField] CommandDate _CommandData;
    [SerializeField] Text _text;

    [SerializeField] GameObject DescriptionWindow;

    // Start is called before the first frame update
    void Start()
    {
        _text.text = $"{_CommandData.commandName}\n({_CommandData.cost.ToString()})";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showDescription()
    {
        descriptionManager script = DescriptionWindow.GetComponent<descriptionManager>();
        script.CommandNameText.text = _CommandData.commandName;
        script.Image.sprite = _CommandData.sprite;
        script.descriptionText.text = _CommandData.description;
        script.DamageText.text = _CommandData.atk.ToString();
        script.CostText.text = _CommandData.cost.ToString();

        if(_CommandData.commandName.Length>6)
        {
            Debug.Log("‚È‚°‚¥");
            script.CommandNameText.fontSize = 26;
        }
        else
        {
            script.CommandNameText.fontSize = 32;
        }

        DescriptionWindow.SetActive(true);
    }


}
