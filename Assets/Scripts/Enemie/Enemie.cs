﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemie : MonoBehaviour
{
    public float Hp;
    private float maxHp;
    public float Damage;
    public float AtackSpeed;
    public float AttackRange = 2;


    public Animator AnimatorController;
    public NavMeshAgent Agent;

    private float lastAttackTime = 0;
    private bool isDead = false;


    public void Init()
    {
        SceneManager.Instance.AddEnemie(this);
        Agent.SetDestination(SceneManager.Instance.Player.transform.position);
        maxHp = Hp;
    }
    public virtual void SpawnEnemiesUnit() { }//доспавн или донастройка юнитов, по типу спавн двух мелких гоблинов в большом

    private void Update()
    {
        if(isDead)
        {
            return;
        }

        if (Hp <= 0)
        {
            Die();
            Agent.isStopped = true;
            return;
        }

        var distance = Vector3.Distance(transform.position, SceneManager.Instance.Player.transform.position);
        if (distance <= AttackRange && SceneManager.Instance.Player.isDead==false)
        {
            Agent.isStopped = true;
            if (Time.time - lastAttackTime > AtackSpeed)
            {
                lastAttackTime = Time.time;
                SceneManager.Instance.Player.TakeDamage(Damage);
                AnimatorController.SetTrigger("Attack");
            }
        }
        else
        {
            Agent.isStopped = false;
            Agent.SetDestination(SceneManager.Instance.Player.transform.position);
        }
        AnimatorController.SetFloat("Speed", Agent.speed); 

    }



    public virtual void Die()
    {
        SceneManager.Instance.RemoveEnemie(this);
        SceneManager.Instance.Player.AddHPVampirism(maxHp);
        isDead = true;
        AnimatorController.SetTrigger("Die");
    }

}
