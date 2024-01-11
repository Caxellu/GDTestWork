using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SpellButton : MonoBehaviour
{
    [SerializeField] private Image imgKd;
    [SerializeField] private Button btn;
    [SerializeField] private string textBtn;
    [SerializeField] private Text textCompBtn;
    private void Awake()
    {
        SetTextSpell(textBtn);
    }
    private void SetTextSpell(string text)
    {
        textCompBtn.text = text;
    }
    public void UpdateKdImg(float current, float max)
    {
        if (current <= 0f)
        {
            imgKd.fillAmount = 1;
        }
        else
            imgKd.fillAmount = 1 - Mathf.Clamp01(current / max);
    }
    public void SetSpellOnBtn(UnityAction action)
    {
        btn.onClick.AddListener(action);
    }
    public void EnableInteractableBtn()
    {
        btn.interactable = true;
        imgKd.color = new Color(188f / 256f, 188f / 256f, 188f / 256f);
    }
    public void DisableInteractableBtn()
    {
        btn.interactable = false;
        imgKd.color = new Color(120f / 256f, 120f / 256f, 120f / 256f);
    }
}
