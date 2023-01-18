using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineScript : MonoBehaviour
{

    Floor[,] map;
    Vector2Int pos;
    int Power=80;
    [SerializeField]GameObject Effect;

    // Start is called before the first frame update
    void Start()
    {
        map = GameObject.FindGameObjectWithTag("Map").GetComponent<Map>().getMap();
        pos = this.gameObject.getMapPosition();
    }

    // Update is called once per frame
    void Update()
    {
        if(map[pos.x,pos.y].getGameObjectOnFloor() is GameObject x)
        {
            x.GetComponent<Object>().Damage(Power);
            Instantiate(Effect, this.transform.position, Quaternion.identity);
            map[pos.x, pos.y].setSubObject(null);
            Destroy(this.gameObject);
        }
    }
}
