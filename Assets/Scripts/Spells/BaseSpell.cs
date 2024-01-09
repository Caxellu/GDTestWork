using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public abstract class BaseSpell: MonoBehaviour
{
    public BaseSpell spell { get { return this; } }
    [SerializeField]
    private float KdDuration;
    [SerializeField]
    private float damage;
    [SerializeField]
    private Image imgKd;
    [SerializeField]
    private float timeCast;
    public bool isKDSpell { get; private set; } = false;
    public bool isCastSpell { get; private set; } = false;
    public virtual void StartKdSpell()
    {
        isKDSpell = true;
       StartCoroutine(KdSpellCorutine(KdDuration, () => isKDSpell = false)) ;
    }
    public virtual void Init(float Kd, float SpellDamage)
    {
        KdDuration = Kd;
        damage = SpellDamage;
    }
    IEnumerator KdSpellCorutine(float duration, UnityAction action)
    {
        float time = 0;
        while(time<duration)
        {
            imgKd.fillAmount = Mathf.Clamp01(time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        imgKd.fillAmount = 1;
       action?.Invoke();
    }
    IEnumerator Wait(float durationWait,UnityAction action)
    {
        yield return new WaitForSeconds(durationWait);
        action?.Invoke();
    }
    public virtual void TryCastSpell()
    {
        if (isKDSpell==false && isCastSpell==false)
        {
            CastSpell();
            StartKdSpell();
            isCastSpell = true;
            StartCoroutine(Wait(timeCast, () => isCastSpell = false));
        }
        else
            Debug.Log("Spell is not Available");
    }
    public abstract void CastSpell();
}