using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoSingleton<GameManager>
{
    [Header("PlayerPrefs")]
    [SerializeField] private bool clearPlayerPrefs;

    private StartUIManager startUIManager;
    private GameUIManager gameUIManager;

    void Start()
    {
        if (clearPlayerPrefs) PlayerPrefs.DeleteAll();

        startUIManager = StartUIManager.Instance;
        gameUIManager = GameUIManager.Instance;

        SetInits();
    }

    private void SetInits()
    {
        startUIManager.Init();
        gameUIManager.Init();
    }

    private void DeInits()
    {
        startUIManager.DeInit();
        gameUIManager.DeInit();
    }

    public void OnLevelSucceed()
    {
        DeInits();
        SetInits();
    }

    public void OnLevelFailed()
    {
        DeInits();
        SetInits();
    }

    public void FinishTheGame()
    {
        ActionManager.GameEnd?.Invoke();
    }
}
