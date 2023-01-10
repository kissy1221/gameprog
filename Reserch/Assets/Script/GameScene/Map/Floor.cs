using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Floor : MonoBehaviour
{
    SpriteRenderer spRen;

    GameObject ObjectOnFloor=null;
    GameObject ObjectOnFloorSub = null;//�����ɔz�u�ł������

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
        //�ݒ肵�Ă���J���[�ɂ���ĕ\���ύX
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


    //�����̃I�u�W�F�N�g��R�Â���
    public void setObject(GameObject obj)
    {
        this.ObjectOnFloor = obj;
    }

    //�z�u������(�\�����ς��)
    public void putObject(GameObject obj)
    {
        this.ObjectOnFloor = obj;
        obj.transform.position = this.PlayerFloorPos;
    }

    public void setSubObject(GameObject obj)
    {
        this.ObjectOnFloorSub = obj;
    }

    //�F���]
    public�@void changeColor()
    {
        this.color = (floorColor)((int)color * -1);
    }

    public void changeColor(floorColor c)
    {
        this.color = c;
    }

    //�I�u�W�F�N�g�Ƀ_���[�W��^����
    public void damageObject(int damage)
    {
        if(this.ObjectOnFloor!=null)
            this.ObjectOnFloor.GetComponent<Object>().Damage(damage);
    }

    //���̏ꏊ�Ɉړ��ł��邩
    public bool canMove()
    {
        if (this.ObjectOnFloor == null)
            return true;
        return false;
    }
}
