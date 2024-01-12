using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public event Action<float, float> EventUpdateHpPlayer;
    public UnityAction EventDiePlayer;

    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float rotateSpeed;

    [SerializeField] private float MaxHp;
    private float CurrentHp;
    public Animator AnimatorController;

    public bool isDead { get; private set; } = false;

    private void Awake()
    {
        CurrentHp = MaxHp;
    }
    private void Start()
    {
        EventDiePlayer += Die;
        EventUpdateHpPlayer?.Invoke(MaxHp, MaxHp);
    }
    private void Update()
    {
        if (isDead)
        {
            return;
        }

        if (CurrentHp <= 0)
        {
            EventDiePlayer?.Invoke();
            return;
        }
    }

    public void AddHPVampirism(float hp)
    {
        ChangeHpPlayer(Mathf.Clamp(CurrentHp + hp, 0.0f, MaxHp));
    }
    public void TakeDamage(float hp)
    {
        ChangeHpPlayer(Mathf.Clamp(CurrentHp - hp, 0.0f, MaxHp));
    }
    private void ChangeHpPlayer(float hp)
    {
        CurrentHp = hp;
        EventUpdateHpPlayer?.Invoke(CurrentHp, MaxHp);
    }
    public void RotatePlayer(Vector2 dir, float koefAcceleration)
    {
        if (dir.magnitude != 0)
        {
            dir.Normalize();
            Quaternion targetLook = Quaternion.LookRotation(new Vector3(dir.x, 0, dir.y), Vector3.up);
            gameObject.transform.rotation = Quaternion.RotateTowards(gameObject.transform.rotation, targetLook, rotateSpeed * koefAcceleration * Time.deltaTime);
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
    }


}
