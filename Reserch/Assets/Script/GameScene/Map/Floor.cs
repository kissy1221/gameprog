using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Floor : MonoBehaviour
{
    SpriteRenderer spRen;

    GameObject ObjectOnFloor=null;
    GameObject ObjectOnFloorSub = null;//同時に配置できるもの

    [SerializeField] Sprite RedFloorSprite;
    [SerializeField] Sprite BlueFloorSprite;
    [SerializeField] public  Vector3 PlayerFloorPos;

    public enum floorColor
    {
        Red=1,
        Blue=-1
    };

    [SerializeField] floorColor color;

    // Start is called before the first frame update
    void Start()
    {
        spRen = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //設定しているカラーによって表示変更
        if(color==floorColor.Red)
        {
            spRen.sprite = RedFloorSprite;
        }
        else
        {
            spRen.sprite = BlueFloorSprite;
        }

    }

    public floorColor Color
    {
        get { return color; }
    }

    public floorColor getColor()
    {
        return this.color;
    }

    
    public GameObject getGameObjectOnFloor()
    {
        return ObjectOnFloor;
    }

    public GameObject getGameObjectOnFloorSub()
    {
        return ObjectOnFloorSub;
    }


    //既存のオブジェクトを紐づける
    public void setObject(GameObject obj)
    {
        this.ObjectOnFloor = obj;
    }

    //配置させる(表示も変わる)
    public void putObject(GameObject obj)
    {
        this.ObjectOnFloor = obj;
        obj.transform.position = this.PlayerFloorPos;
    }

    public void setSubObject(GameObject obj)
    {
        this.ObjectOnFloorSub = obj;
    }

    //色反転
    public　void changeColor()
    {
        this.color = (floorColor)((int)color * -1);
    }

    public void changeColor(floorColor c)
    {
        this.color = c;
    }

    //オブジェクトにダメージを与える
    public void damageObject(int damage)
    {
        if(this.ObjectOnFloor!=null)
            this.ObjectOnFloor.GetComponent<Object>().Damage(damage);
    }

    //この場所に移動できるか
    public bool canMove()
    {
        if (this.ObjectOnFloor == null)
            return true;
        return false;
    }
}
