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

    public GameObject getGameObjectOnFloorSub()
    {
        return ObjectOnFloorSub;
    }


    //既存のオブジェクトを紐づける
    public void setObject(GameObject obj)
    {
        this.ObjectOnFloor = obj;
    }

    public void setSubObject(GameObject obj)
    {
        this.ObjectOnFloorSub = obj;
    }

    //色反転
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

    public void changeColor(floorColor c)
    {
        if (c == floorColor.Red)
        {
            color = floorColor.Red;
            spRen.sprite = RedFloorSprite;
        }
        else
        {
            color = floorColor.Blue;
            spRen.sprite = BlueFloorSprite;
        }
    }
}
