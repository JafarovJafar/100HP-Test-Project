using System;
using UnityEngine;

[Serializable]
public class Stat
{
    [field: SerializeField] public float Value { get; private set; }
    [field: SerializeField] public float Coast { get; private set; }
}