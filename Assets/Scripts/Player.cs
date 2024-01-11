using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float rotateSpeed;

    [SerializeField]private float MaxHp;
    private float CurrentHp;
    public Animator AnimatorController;

    private bool isDead = false;
    

    private void Awake()
    {
        MaxHp = CurrentHp;
    }
    private void Update()
    {
        if (isDead)
        {
            return;
        }

        if (CurrentHp <= 0)
        {
            Die();
            return;
        }
    }

    public void AddHPVampirism(float hp)
    {
        CurrentHp = Mathf.Clamp(CurrentHp + hp, 0.0f, MaxHp);
    }
    public void TakeDamage(float hp)
    {
        CurrentHp = Mathf.Clamp(CurrentHp - hp, 0.0f, MaxHp);
    }
    public void RotatePlayer(Vector2 dir, float koefAcceleration)
    {
        if (dir.magnitude != 0)
        {
            dir.Normalize();
            Quaternion targetLook = Quaternion.LookRotation(new Vector3(dir.x, 0, dir.y), Vector3.up);
            gameObject.transform.rotation = Quaternion.RotateTowards(gameObject.transform.rotation, targetLook, rotateSpeed* koefAcceleration * Time.deltaTime);
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
