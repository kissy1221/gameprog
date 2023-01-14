using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class isBlindOption : MonoBehaviour
{
    [SerializeField] Toggle isBlindToggle; //�`�F�b�N�����邩
    [SerializeField] Dropdown BlindNumDropDown; //�Öق̐�

    public bool isBlindOn { get => isBlindToggle.isOn; set { isBlindToggle.isOn = value; } }

    public void setBlindNum(int num)
    {
        BlindNumDropDown.value = num - 1;
    }
    
    public int getBlindNum()
    {
        return BlindNumDropDown.value + 1;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        BlindNumDropDown.interactable = isBlindToggle.isOn;
    }
}
