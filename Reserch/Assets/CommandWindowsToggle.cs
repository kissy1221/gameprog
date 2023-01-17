using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommandWindowsToggle : MonoBehaviour
{
    Toggle toggle;
    [SerializeField]GameObject commandwin;
    void Start()
    {
        toggle = GetComponent<Toggle>();
    }

    // Update is called once per frame
    void Update()
    {
        //commandwin.SetActive(toggle.isOn);
    }
}
