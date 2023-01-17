using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionDB
{
    public static Dictionary<ConditionID, Condition> Conditions { get; set; } = new Dictionary<ConditionID, Condition>()
    {
        {
            ConditionID.Poison,
            new Condition()
            {
                Name="毒"
            }
        },
        {
            ConditionID.Blind,
            new Condition()
            {
                Name="盲目"
            }
        },
        {
            ConditionID.CompileError,
            new Condition()
            {
                Name="盲目"
            }
        }
    };
}

public enum ConditionID
{
    None,   //何もなし
    CompileError,   //コンパイルエラー
    Blind,  //暗黙
    Poison, //毒
    Stun    //気絶
}
