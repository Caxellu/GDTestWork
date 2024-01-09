using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance = null;
    [SerializeField]
    private Button _btnSpell1;
    [SerializeField]
    private Button _btnSpell2;
    public Button BtnSpell1 { get { return _btnSpell1; } }
    public Button BtnSpell2 { get { return _btnSpell2; } }
    private void Awake()
    {
        Instance = this;
    }
}
