using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="CreateEnemyData")]
public class EnemyData : ScriptableObject
{
    [SerializeField] new string name;
    [SerializeField]Sprite _Icon;

    public string Name { get => name; }
    public Sprite Icon { get => _Icon; }
}
