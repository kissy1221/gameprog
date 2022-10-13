using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square
{
    Object ObjectOnFloor;//è„Ç…îzíuÇ≥ÇÍÇƒÇ¢ÇÈÇ‡ÇÃ
    Floor floor; 

    public Square(Floor floor,Object obj)
    {
        ObjectOnFloor = obj;
        this.floor = floor;
    }

    public Floor getFloorColor()
    {
        return floor;
    }

    public Object getObjectOnFloor()
    {
        return ObjectOnFloor;
    }

    public void putObjectOnFloor(Object obj)
    {
        ObjectOnFloor = obj;
    }
}
