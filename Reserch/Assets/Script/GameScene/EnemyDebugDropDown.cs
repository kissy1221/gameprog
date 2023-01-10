using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDebugDropDown : MonoBehaviour
{
    // Start is called before the first frame update

    Dropdown dropdown;
    [SerializeField]enemyDebugPanel panel;
    

    void Start()
    {

        dropdown = GetComponent<Dropdown>();

        foreach (GameObject enemy in EnemyManager.Instance.Enemies)
        {
            dropdown.options.Add(new Dropdown.OptionData { text = enemy.name });
        }
        dropdown.RefreshShownValue();
    }

    // Update is called once per frame
    void Update()
    {
        panel.selectEnemyObject = EnemyManager.Instance.gameObject.transform.GetChild(dropdown.value).gameObject;
    }
}
