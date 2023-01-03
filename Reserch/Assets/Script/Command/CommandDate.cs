using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName ="CommandDate")]
public class CommandDate : ScriptableObject
{
    public enum commandType
    {
        Backbone,
        Atack,
        Support
    }

    public string commandName;
    [TextArea]
    public string description;
    public commandType type;
    public int atk;
    public int cost;
    public Sprite sprite;
    
    
}
