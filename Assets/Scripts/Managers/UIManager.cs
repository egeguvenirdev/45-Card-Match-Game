using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class UIManager : MonoSingleton<UIManager>
{
    [Header("Panels")]
    [SerializeField] private PanelBase[] panels;

    [Header("Text Props")]
    [SerializeField] private TMP_Text timerText;


    private LevelManager levelManager;

    public void Init()
    {
        levelManager = LevelManager.Instance;

        for (int i = 0; i < panels.Length; i++)
        {
            panels[i].Init();
        }
    }

    public void DeInit()
    {
        for (int i = 0; i < panels.Length; i++)
        {
            panels[i].DeInit();
        }
    }

    public void TimerText(string refText)
    {
        timerText.text = refText;
    }
}
