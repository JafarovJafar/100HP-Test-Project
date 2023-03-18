using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Stats")]
public class Stats : ScriptableObject
{
    [field: SerializeField] public List<float> Values { get; private set; } = new List<float>();
}