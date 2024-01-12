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
        ChangeCastTimer(CastTime);
        IsCast = true;

        Enemie closestEnemie = FindClosestEnemie();
        if (closestEnemie != null)
        {
            float distance = Vector3.Distance(SceneManager.Instance.Player.transform.position, closestEnemie.transform.position);
            if (distance <= AttackRange)
            {
                SceneManager.Instance.Player.transform.LookAt(new Vector3(closestEnemie.transform.position.x,0, closestEnemie.transform.position.z));
                //SceneManager.Instance.Player.RotatePlayer(closestEnemie.transform.position - SceneManager.Instance.Player.transform.position, 1000);
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

        Enemie closestEnemie = FindClosestEnemie();
        if(closestEnemie!=null)
        {
            float distance = Vector3.Distance(SceneManager.Instance.Player.transform.position, closestEnemie.transform.position);
            if (distance <= AttackRange)
            {
                isEnemiNear = true;
                IsAvailable = true;
            }
            else
            {
                isEnemiNear = false;
                IsAvailable = false;
            }
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
        CheckKD();
    }
    public override bool CheckKD()
    {
        if ( CooldownTimer == 0.0f)
            return false;
        else
            return true;
    }

}
