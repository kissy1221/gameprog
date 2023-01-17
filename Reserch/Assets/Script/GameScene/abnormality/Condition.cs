using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//キャラクターの状態異常
public class Condition
{
    public string Name { get; set; } //状態異常名
    public string Description { get; set; }//状態異常の説明

    public Sprite ConditionIcon { get; set; }   //状態異常アイコン
}
