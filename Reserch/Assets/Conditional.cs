using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Conditional : MonoBehaviour
{
    Dropdown conditionalDropDown;
    GameObject player;

    private void Start()
    {
        conditionalDropDown = GetComponent<Dropdown>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public bool checkConditonal()
    {
        bool flag=false;
        switch(conditionalDropDown.value)
        {
            case 0://前方に敵がいたら
                flag = isEnemyinFront();
                break;
            case 1://前方に敵がいなかったら
                Debug.Log("前方にてきがいなかったら");
                break;
            case 2://最後列に敵がいたら
                flag= isEnemyInLastRow();
                break;
            case 3://最前列に敵がいたら
                flag=isEnemyInFrontRow();
                break;
        }

        return flag;

    }

    
    bool isEnemyinFront()
    {

       Vector2Int playerPos = player.getMapPosition();

        for(int i=playerPos.x+1;i<Const.CO.MAP_SIZE.X;i++)
        {
            GameObject g = Map.Instance.getMap()[i,playerPos.y ].getGameObjectOnFloor();
            if (g != null)
            {
                if (g.tag == "Enemy")
                    return true;
            }
        }
        
        return false;
    }

    bool isNotEnemyInFront()
    {
        Vector2Int playerPos = player.getMapPosition();

        for (int i = playerPos.x + 1; i < Const.CO.MAP_SIZE.X; i++)
        {
            GameObject g = Map.Instance.getMap()[i, playerPos.y].getGameObjectOnFloor();
            if (g != null)
            {
                if (g.tag == "Enemy")
                    return false;
            }
        }

        return true;
    }

    bool isEnemyInLastRow()
    {
        for(int i=0;i<Map.Instance.getMap().GetLength(1); i++)
        {
            GameObject g = Map.Instance.getMap()[7, i].getGameObjectOnFloor();
            if(g!=null)
            {
                if(g.tag=="Enemy")
                    return true;
            }
        }
        return false;
    }

    //エリアスチールを使うと変わる
    bool isEnemyInFrontRow()
    {
        for (int i = 0; i < Map.Instance.getMap().GetLength(1); i++)
        {
            GameObject g = Map.Instance.getMap()[4, i].getGameObjectOnFloor();
            if (g != null)
            {
                if (g.tag == "Enemy")
                    return true;
            }
        }
        return false;
    }
    

}
