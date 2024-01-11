using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance = null;
    [SerializeField] private SpellButton spellBtn1;
    [SerializeField] private SpellButton spellBtn2;
    private void Awake()
    {
        Instance = this;

    }
    public void InitSpellUI(Spell[] spells)
    {
        spells[0].EventChangeCooldownTimer += spellBtn1.UpdateKdImg;
        spells[0].EventYESAvailableSpell+= spellBtn1.EnableInteractableBtn;
        spells[0].EventNOTAvailableSpell += spellBtn1.DisableInteractableBtn;
        spellBtn1.SetSpellOnBtn(()=>SpellCastHandler.Instance.OnClickAbilityButton(spells[0]));

        spells[1].EventChangeCooldownTimer += spellBtn2.UpdateKdImg;
        spells[1].EventYESAvailableSpell += spellBtn2.EnableInteractableBtn;
        spells[1].EventNOTAvailableSpell += spellBtn2.DisableInteractableBtn;
        spellBtn2.SetSpellOnBtn(() => SpellCastHandler.Instance.OnClickAbilityButton(spells[1]));
    }
}
