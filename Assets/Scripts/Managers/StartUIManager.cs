using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class StartUIManager : MonoSingleton<StartUIManager>
{
    [Header("Panels")]
    [SerializeField] private PanelBase[] panels;

    [Header("Components")]
    [SerializeField] private GameObject canvas;

    [Header("Text Props")]
    [SerializeField] private TMP_Text timerText;


    private LevelManager levelManager;

    public void Init()
    {
        levelManager = LevelManager.Instance;

        ActionManager.GameStart += OnGameStart;
        ActionManager.GameEnd += OnGameEnd;

        for (int i = 0; i < panels.Length; i++)
        {
            panels[i].Init();
        }
    }

    public void DeInit()
    {
        ActionManager.GameStart -= OnGameStart;
        ActionManager.GameEnd -= OnGameEnd;

        for (int i = 0; i < panels.Length; i++)
        {
            panels[i].DeInit();
        }
    }

    public void TimerText(string refText)
    {
        timerText.text = refText;
    }

    private void OnGameStart()
    {
        canvas.SetActive(false);
    }

    private void OnGameEnd()
    {
        canvas.SetActive(false);
    }
}
