using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoSingleton<GameManager>
{
    [Header("PlayerPrefs")]
    [SerializeField] private bool clearPlayerPrefs;

    private PlayerManager playerManager;
    private LevelManager levelManager;
    private UpdateManager updateManager;
    private CamManager camManager;
    private StartUIManager startUIManager;
    private GameUIManager gameUIManager;
    private AudioManager audioManager;

    void Start()
    {
        if (clearPlayerPrefs) PlayerPrefs.DeleteAll();

        levelManager = LevelManager.Instance;
        startUIManager = StartUIManager.Instance;
        gameUIManager = GameUIManager.Instance;
        updateManager = FindObjectOfType<UpdateManager>();
        camManager = FindObjectOfType<CamManager>();
        audioManager = FindObjectOfType<AudioManager>();

        SetInits();
    }

    private void SetInits()
    {
        levelManager.Init();
        startUIManager.Init();
        gameUIManager.Init();
        updateManager.Init();
        audioManager.Init();
    }

    private void DeInits()
    {
        levelManager.DeInit();
        startUIManager.DeInit();
        gameUIManager.DeInit();
        updateManager.DeInit();
        camManager.DeInit();
        audioManager.DeInit();
    }

    public void OnStartTheGame()
    {
        ActionManager.GameStart?.Invoke();

        playerManager = FindObjectOfType<PlayerManager>();
        playerManager.Init();

        camManager.Init();
    }

    public void OnLevelSucceed()
    {
        levelManager.LevelUp();
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
        playerManager.DeInit();
        ActionManager.GameEnd?.Invoke();
    }
}
