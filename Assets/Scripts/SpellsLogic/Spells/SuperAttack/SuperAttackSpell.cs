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

        Enemie closestEnemie = FindClosestEnemie();
        if (closestEnemie != null)
        {
            float distance = Vector3.Distance(SceneManager.Instance.Player.transform.position, closestEnemie.transform.position);
            if (distance <= AttackRange)
            {
                SceneManager.Instance.Player.RotatePlayer(closestEnemie.transform.position - SceneManager.Instance.Player.transform.position, 1000);
                closestEnemie.Hp -= Damage;
            }
        }
    }
    public override void EventTick(float deltaTick)
    {
        if (isAvailbale == false)
            ChangeCooldownTimer(CooldownTimer - deltaTick);

        Enemie closestEnemie = FindClosestEnemie();
        if(closestEnemie!=null)
        {
            float distance = Vector3.Distance(SceneManager.Instance.Player.transform.position, closestEnemie.transform.position);
            if (distance <= AttackRange)
                isEnemiNear = true;
            else
                isEnemiNear = false;
        }




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

}
