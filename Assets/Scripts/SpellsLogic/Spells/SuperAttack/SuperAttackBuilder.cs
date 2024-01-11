using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperAttackBuilder : SpellBuilder
{
    private readonly SuperAttackConfig _config;

    public SuperAttackBuilder(SuperAttackConfig config) : base(config)
    {
        _config = config;
    }

    public override void Make()
    {
        _spell = new SuperAttackSpell(_config.AttackRange);
        base.Make();
    }
}
