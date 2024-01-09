using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance = null;

    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float rotateSpeed;

    public float Hp;
    public float Damage;
    public float AtackSpeed;
    public float AttackRange = 2;
    public Animator AnimatorController;

    private float lastAttackTime = 0;
    private bool isDead = false;

    private void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        if (isDead)
        {
            return;
        }

        if (Hp <= 0)
        {
            Die();
            return;
        }


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

            var distance = Vector3.Distance(transform.position, enemie.transform.position);
            var closestDistance = Vector3.Distance(transform.position, closestEnemie.transform.position);

            if (distance < closestDistance)
            {
                closestEnemie = enemie;
            }

        }

        if (closestEnemie != null)
        {
            var distance = Vector3.Distance(transform.position, closestEnemie.transform.position);
            if (distance <= AttackRange)
            {
                if (Time.time - lastAttackTime > AtackSpeed)
                {
                    //transform.LookAt(closestEnemie.transform);
                    transform.transform.rotation = Quaternion.LookRotation(closestEnemie.transform.position - transform.position);

                    lastAttackTime = Time.time;
                    closestEnemie.Hp -= Damage;
                    AnimatorController.SetTrigger("Attack");
                }
            }
        }
    }
    public void RotatePlayer(Vector2 dir)
    {
        if (dir.magnitude != 0)
        {
            Quaternion targetLook = Quaternion.LookRotation(new Vector3(dir.x, 0, dir.y), Vector3.up);
            gameObject.transform.rotation = Quaternion.RotateTowards(gameObject.transform.rotation, targetLook, rotateSpeed * Time.deltaTime);
        }
    }
    public void MovePlayer(Vector2 dir)
    {
        if (dir.magnitude == 0)
        {
            AnimatorController.SetFloat("Speed", 0);
        }
        else
        {
            AnimatorController.SetFloat("Speed", moveSpeed);
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, gameObject.transform.position + new Vector3(dir.x,0,dir.y) * moveSpeed, moveSpeed * Time.deltaTime);
        }
    }
    private void Die()
    {
        isDead = true;
        AnimatorController.SetTrigger("Die");

        SceneManager.Instance.GameOver();
    }


}
