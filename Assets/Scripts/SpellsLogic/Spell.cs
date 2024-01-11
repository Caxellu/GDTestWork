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
    public float Damage { get; private set; }
    public bool isAvailbale => CheckCondition();

    public void SetBaseSpell(float coolDownTime,float damage, string key, Animator animator)
    {
        CooldownTime = coolDownTime;
        Damage = damage;
        AnimKey = key;
        AnimatorController = animator;
    }
    public void ChangeCooldownTimer(float timer)
    {
        CooldownTimer = Mathf.Clamp(timer, 0.0f, CooldownTime);
        EventChangeCooldownTimer?.Invoke(CooldownTimer, CooldownTime);
    }
    public virtual void EventTick(float deltaTick) { }
    public virtual bool CheckCondition()
    {
        if (CooldownTimer == 0.0f)
            return true;
        else
            return false;
    }
    public virtual void CastSpell(){}
    public virtual void EndCastSpell() { }
}
