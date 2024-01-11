using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCastHandler : MonoBehaviour
{
    public static SpellCastHandler Instance = null;
    [SerializeField] private SpellStorage _spellStorage;
    [SerializeField] private Player _player;

    private List<Spell> _spells = new List<Spell>();
    private Spell _currentspell=null;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        _spellStorage.Init();
        _spells.AddRange(_spellStorage.GetSpells());
        UIManager.Instance.InitSpellUI(_spellStorage.GetSpells());
    }
    private void Update()
    {
        for (int i = 0; i < _spells.Count; i++)
        {
            _spells[i].EventTick(Time.deltaTime);
        }

        if(_currentspell!=null)
        {
            if (_currentspell.isAvailbale)
                _currentspell = null;
        }
        else
        {
            if (InputManager.Instance.OnKey(KeyCode.J))//костыль
            {
                OnClickAbilityButton(_spells[0]);
            }
            if (InputManager.Instance.OnKey(KeyCode.K))//костыль
            {
                OnClickAbilityButton(_spells[1]);
            }
        }
    }
    public void OnClickAbilityButton(Spell spell)
    {
        if (spell.isAvailbale)
        {
            _currentspell = spell;
            _currentspell.CastSpell();
        }
    }
}
