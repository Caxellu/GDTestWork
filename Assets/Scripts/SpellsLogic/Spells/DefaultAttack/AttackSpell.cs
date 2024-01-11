using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSpell : Spell
{
    public float AttackRange { get; private set; }

    public AttackSpell ( float attackRange)
    {
        AttackRange = attackRange;
    }
    public override void CastSpell()
    {
        AnimatorController.SetTrigger(AnimKey);
        ChangeCooldownTimer(CooldownTime);
        IsCast = true;

        Enemie closestEnemie = FindClosestEnemie();
        if (closestEnemie != null)
        {
            var distance = Vector3.Distance(SceneManager.Instance.Player.transform.position, closestEnemie.transform.position);
            if (distance <= AttackRange)
            {
                SceneManager.Instance.Player.RotatePlayer(closestEnemie.transform.position - SceneManager.Instance.Player.transform.position,1000);
                    closestEnemie.Hp -= Damage;
            }
        }
    }
    public override void EventTick(float deltaTick)
    {
        if (IsKD)
            ChangeCooldownTimer(CooldownTimer - deltaTick);

        if (IsCast)
            ChangeCastTimer(CastTimer - deltaTick);
    }
}
