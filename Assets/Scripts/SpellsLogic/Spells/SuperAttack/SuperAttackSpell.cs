using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperAttackSpell : Spell
{
    public float AttackRange { get; private set; }

    bool isEnemiNear = false;
    public SuperAttackSpell(float attackRange)
    {
        AttackRange = attackRange;
    }
    public override void CastSpell()
    {
        AnimatorController.SetTrigger(AnimKey);
        ChangeCooldownTimer(CooldownTime);

    }
    public override void EventTick(float deltaTick)
    {
        if (isAvailbale == false)
            ChangeCooldownTimer(CooldownTimer - deltaTick);

        isEnemiNear = ISEnemieNear(AttackRange);
        if (isEnemiNear)
        {
            //button enable
            EventYESAvailableSpell?.Invoke();
        }
        else
        {
            //button disable
            EventNOTAvailableSpell?.Invoke();
        }

        CheckCondition();
    }
    public override bool CheckCondition()
    {
        if (isEnemiNear && CooldownTimer == 0.0f)
            return true;
        else
            return false;
    }
    private bool ISEnemieNear(float attackRange)
    {
        var enemies = SceneManager.Instance.Enemies;

        for (int i = 0; i < enemies.Count; i++)
        {
            var enemie = enemies[i];
            if (enemie == null)
            {
                continue;
            }
            var distance = Vector3.Distance(Player.Instance.transform.position, enemie.transform.position);
            if (distance <= attackRange)
                return true;
        }
        return false;
    }
}
