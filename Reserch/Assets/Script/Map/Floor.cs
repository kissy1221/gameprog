using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Floor : MonoBehaviour
{
    SpriteRenderer spRen;

    GameObject ObjectOnFloor;//

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

    publicÅ@void changeColor()
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
