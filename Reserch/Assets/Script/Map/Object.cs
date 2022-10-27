using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Object : MonoBehaviour
{

    [SerializeField] int HP;
    [SerializeField] GameObject TextObject;
    Text HPText;

    // Start is called before the first frame update
    protected void Start()
    {
        HPText = TextObject.GetComponent<Text>();
    }

    // Update is called once per frame
    protected void Update()
    {
        HPText.text = HP.ToString();
    }

    public void Damage(int damage)
    {
        HP -= damage;

        if(HP<=0)
        {
            Destroy(this.gameObject);
            this.gameObject.DestroyfromMap();
        }
    }

    public void setHP(int HP)
    {
        this.HP = HP;
    }


}
