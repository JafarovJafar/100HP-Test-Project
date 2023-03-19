using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Stats")]
public class Stats : ScriptableObject
{
    [field: SerializeField] public List<Stat> Values { get; private set; }
}