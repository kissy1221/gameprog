using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Object : MonoBehaviour
{

    [SerializeField] int HP;
    [SerializeField]Text HPText;

    // Start is called before the first frame update
    protected virtual void Start()
    {

    }

    // Update is called once per frame
    protected virtual void Update()
    {
        HPText.text = HP.ToString();
    }

    public void Damage(int damage)
    {
        GameObject damageText = Resources.Load("Prefab/DamageText") as GameObject;
        GameObject canvas = this.gameObject.transform.Find("Canvas").gameObject;

        GameObject text;
        text = Instantiate(damageText, new Vector3(this.transform.position.x, this.transform.position.y,canvas.transform.position.z), Quaternion.identity,canvas.transform);

        /*
        text.transform.SetParent(canvas.transform, false);
        text.transform.position = this.gameObject.transform.position;
        */

        text.GetComponent<Text>().text = damage.ToString();

        HP -= damage;

        if(HP<=0)
        {
            Death();
        }
    }

    protected virtual void Death()
    {
        Destroy(this.gameObject);
        this.gameObject.DestroyfromMap();
    }

    public void setHP(int HP)
    {
        this.HP = HP;
    }


}
