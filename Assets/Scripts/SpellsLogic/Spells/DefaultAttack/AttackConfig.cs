using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Game/Spells/DefaultAttack", fileName ="DefaultAttackConfig")]
public class AttackConfig : SpellConfig
{
    [field: SerializeField] public float AttackRange { get; private set; }

    public override SpellBuilder GetBuilder()
    {
        return new AttackBuilder(this);
    }
}
