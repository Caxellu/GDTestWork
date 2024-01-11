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

        Enemie closestEnemie = FindClosestEnemie();

        if (closestEnemie != null)
        {
            var distance = Vector3.Distance(Player.Instance.transform.position, closestEnemie.transform.position);
            if (distance <= AttackRange)
            {
                    Player.Instance.RotatePlayer(closestEnemie.transform.position - Player.Instance.transform.position,1000);
                    closestEnemie.Hp -= Damage;
            }
        }
    }
    public override void EventTick(float deltaTick)
    {
        if (isAvailbale == false)
            ChangeCooldownTimer(CooldownTimer - deltaTick);

    }
    private Enemie FindClosestEnemie()
    {
        var enemies = SceneManager.Instance.Enemies;
        Enemie closestEnemie = null;

        for (int i = 0; i < enemies.Count; i++)
        {
            var enemie = enemies[i];
            if (enemie == null)
            {
                continue;
            }

            if (closestEnemie == null)
            {
                closestEnemie = enemie;
                continue;
            }

            var distance = Vector3.Distance(Player.Instance.transform.position, enemie.transform.position);
            var closestDistance = Vector3.Distance(Player.Instance.transform.position, closestEnemie.transform.position);

            if (distance < closestDistance)
            {
                closestEnemie = enemie;
            }
        }
        return closestEnemie;
    }
}
