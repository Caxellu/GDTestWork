using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/Spells/SuperAttack", fileName = "SuperAttackConfig")]
public class SuperAttackConfig : SpellConfig
{
    [field: SerializeField] public float AttackRange { get; private set; }

    public override SpellBuilder GetBuilder()
    {
        return new SuperAttackBuilder(this);
    }
}
