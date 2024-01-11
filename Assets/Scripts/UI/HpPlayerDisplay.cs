using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpPlayerDisplay : MonoBehaviour
{
    [SerializeField] private Image ImgProgrgressBar;
    [SerializeField] private Text TextCurrentHpToMaxHp;

    public void Start()
    {
        SceneManager.Instance.Player.EventUpdateHpPlayer += DisplayCurrentHP;
    }
    private void DisplayCurrentHP(float currentHp, float maxHp)
    {
        TextCurrentHpToMaxHp.text = currentHp + "/" + maxHp;
        ImgProgrgressBar.fillAmount = currentHp / maxHp;
    }
}
