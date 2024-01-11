using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellConfig : ScriptableObject
{
    [field: SerializeField] public float CooldownTime { get; private set; }
    [field: SerializeField] public float CastTime { get; private set; }
    [field: SerializeField] public string AnimKey { get; private set; }
    [field: SerializeField] public float Damage { get; private set; }
    public virtual SpellBuilder GetBuilder() => new SpellBuilder(this);
}
