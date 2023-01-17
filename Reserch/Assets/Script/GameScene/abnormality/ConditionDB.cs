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
                Name="��"
            }
        },
        {
            ConditionID.Blind,
            new Condition()
            {
                Name="�Ӗ�"
            }
        },
        {
            ConditionID.CompileError,
            new Condition()
            {
                Name="�Ӗ�"
            }
        }
    };
}

public enum ConditionID
{
    None,   //�����Ȃ�
    CompileError,   //�R���p�C���G���[
    Blind,  //�Ö�
    Poison, //��
    Stun    //�C��
}
