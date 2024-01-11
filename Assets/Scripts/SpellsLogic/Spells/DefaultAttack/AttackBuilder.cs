using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBuilder : SpellBuilder
{
    private readonly AttackConfig _config;

     public AttackBuilder(AttackConfig config) :base(config)
     {
         _config = config;
     }

    public override void Make()
    {
        _spell = new AttackSpell(_config.AttackRange);
        base.Make();
    }
}
