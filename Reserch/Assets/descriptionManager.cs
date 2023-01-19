using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class descriptionManager : MonoBehaviour
{
    public Text CommandNameText;
    public Image Image;
    public Text descriptionText;
    public Text DamageText;
    public Text CostText;

    public void ExitButton()
    {
        this.gameObject.SetActive(false);
    }
}
