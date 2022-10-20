using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square
{
    //Object ObjectOnFloor;//è„Ç…îzíuÇ≥ÇÍÇƒÇ¢ÇÈÇ‡ÇÃ
    GameObject ObjectOnFloor;
    Floor floor; 

    public Square(Floor floor,GameObject obj)
    {
        ObjectOnFloor = obj;
        this.floor = floor;
    }

    public Floor getFloorColor()
    {
        return floor;
    }

    public GameObject getObjectOnFloor()
    {
        return ObjectOnFloor;
    }

    public void putObjectOnFloor(GameObject obj)
    {
        ObjectOnFloor = obj;
    }
}
