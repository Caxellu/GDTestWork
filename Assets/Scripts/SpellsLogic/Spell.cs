using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spell 
{
    public event Action<float, float> EventChangeCooldownTimer;
    public UnityAction EventNOTAvailableSpell;
    public UnityAction EventYESAvailableSpell;

    public Animator AnimatorController { get; private set; }
    public string AnimKey { get; private set; }
    public float CooldownTime { get; private set; }
    public float CooldownTimer { get; private set; }
    public float CastTime{ get; private set; }
    public float CastTimer { get; private set; }
    public float Damage { get; private set; }
    public bool IsKD => CheckKD();
    public bool IsCast = false;
    public bool IsAvailable=true;//special conditions is check?

    public void SetBaseSpell(float coolDownTime,float castTime,float damage, string key, Animator animator)
    {
        CooldownTime = coolDownTime;
        CastTime = castTime;
        Damage = damage;
        AnimKey = key;
        AnimatorController = animator;
    }
    public void ChangeCooldownTimer(float timer)
    {
        CooldownTimer = Mathf.Clamp(timer, 0.0f, CooldownTime);
        EventChangeCooldownTimer?.Invoke(CooldownTimer, CooldownTime);
    }
    public void ChangeCastTimer(float timer)
    {
        CastTimer = Mathf.Clamp(timer, 0.0f, CastTime);
        if (CastTimer == 0.0f)
            IsCast = false;
    }
    public virtual void EventTick(float deltaTick) { }
    public virtual bool CheckKD()
    {
        if (CooldownTimer == 0.0f)
            return false;
        else
            return true;
    }
    public virtual void CastSpell(){}
    public virtual void EndCastSpell() { }
    public Enemie FindClosestEnemie()
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

            var distance = Vector3.Distance(SceneManager.Instance.Player.transform.position, enemie.transform.position);
            var closestDistance = Vector3.Distance(SceneManager.Instance.Player.transform.position, closestEnemie.transform.position);

            if (distance < closestDistance)
            {
                closestEnemie = enemie;
            }
        }
        return closestEnemie;
    }
}
