using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Const;

public class CostText : MonoBehaviour
{
    Text costText;
    // Start is called before the first frame update
    void Start()
    {
        costText = this.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        costText.text = getSumCost() + "/" + Const.CO.MAX_COST;
    }
    
    int getSumCost()
    {
        GameObject deckListObj = transform.parent.gameObject;
        DeckList deckscript = deckListObj.GetComponent<DeckList>();

        int sumCost=0;

        foreach(CommandDate com in deckscript.deck)
        {
            sumCost += com.cost;
        }
        return sumCost;
    }
}
