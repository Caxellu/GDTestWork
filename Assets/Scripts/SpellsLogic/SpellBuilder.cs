using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellBuilder 
{
    private SpellConfig _config;
    protected Spell _spell;

    public SpellBuilder(SpellConfig config)
    {
        _config = config;
    }

    public virtual void Make()
    {
        if (_spell != null)
        {
            _spell.SetBaseSpell(_config.CooldownTime, _config.Damage,_config.AnimKey, Player.Instance.AnimatorController);
        }
    }

    public virtual Spell GetResult() => _spell;
}
