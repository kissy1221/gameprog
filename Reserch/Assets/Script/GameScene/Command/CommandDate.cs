using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[CreateAssetMenu(menuName ="CommandDate")]
public class CommandDate : ScriptableObject
{
    public enum commandType
    {
        Backbone,
        Atack,
        Support
    }

    public enum commandUser
    {
        Common,
        Enemy,
        Player
    }

    public string commandName;
    [TextArea]
    public string description;
    public commandType type;
    public commandUser user;
    public int atk;
    public int cost;
    public Sprite sprite;
    public GameObject obj;
    
    
}
