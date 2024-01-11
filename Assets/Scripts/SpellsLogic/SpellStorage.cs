using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellStorage : MonoBehaviour
{
    [SerializeField] private SpellConfig[] _spellConfigs;
    [SerializeField] private Player _player;
    private List<Spell> _spells = new List<Spell>();
    public void Init()
    {
        for (int i = 0; i < _spellConfigs.Length; i++)
        {
            SpellBuilder builder = _spellConfigs[i].GetBuilder();
            builder.Make();
            _spells.Add(builder.GetResult());
        }
    }
    public Spell[] GetSpells() => _spells.ToArray();
}
