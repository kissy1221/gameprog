using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Floor : MonoBehaviour
{
    SpriteRenderer spRen;

    GameObject ObjectOnFloor=null;

    [SerializeField] Sprite RedFloorSprite;
    [SerializeField] Sprite BlueFloorSprite;

    public enum floorColor
    {
        Red,
        Blue
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


    }

    public floorColor getColor()
    {
        return this.color;
    }

    
    public GameObject getGameObjectOnFloor()
    {
        return ObjectOnFloor;
    }


    //既存のオブジェクトを紐づける
    public void setObject(GameObject obj)
    {
        this.ObjectOnFloor = obj;
    }

    //配置
    public void putObject(GameObject obj)
    {

    }

    public　void changeColor()
    {
        if (color == floorColor.Red)
        {
            color = floorColor.Blue;
            spRen.sprite = BlueFloorSprite;
        }
        else
        {
            color = floorColor.Red;
            spRen.sprite = RedFloorSprite;
        }
    }
}
