using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameUIManager : MonoSingleton<GameUIManager>
{
    [Header("Game Infos")]
    [SerializeField] private GamePlayInfos gameInfo;

    [Header("Components")]
    [SerializeField] private CardManager cardManager;
    [SerializeField] private GameObject canvas;
    [SerializeField] private TMP_Text roundText;
    [SerializeField] private PlayerProfile player1;
    [SerializeField] private PlayerProfile player2;

    private int currentRound = 1;

    [Header("Player 1")]
    [SerializeField] private TMP_Text playerOnePointText;
    private int playerOnePoint;
    [SerializeField] private TMP_Text playerOneScoreText;
    private int playerOneScore;

    [Header("Player 2")]
    [SerializeField] private TMP_Text playerTwoPointText;
    private int playerTwoPoint;
    [SerializeField] private TMP_Text playerTwoScoreText;
    private int playerTwoScore;


    private int playQueue;

    public void Init()
    {
        ActionManager.GameStart += OnGameStart;
        ActionManager.GameEnd += OnGameEnd;
        ActionManager.PlayQueueChange += OnPlayQueueChange;

        cardManager.Init();

        roundText.text = "Round: " + currentRound + " / " + gameInfo.GetGameInfos.RoundCount;
        playerOnePointText.text = "Point: " + playerOnePoint;
        playerOneScoreText.text = "Score: " + playerOneScore;

        playerTwoPointText.text = "Point: " + playerTwoPoint;
        playerTwoScoreText.text = "Score: " + playerTwoScore;
    }

    public void DeInit()
    {
        ActionManager.GameStart -= OnGameStart;
        ActionManager.GameEnd -= OnGameEnd;
        ActionManager.PlayQueueChange -= OnPlayQueueChange;

        cardManager.DeInit();
    }

    private void OnGameStart()
    {
        canvas.SetActive(true);
        OnPlayQueueChange();
        cardManager.CreateCards(gameInfo.GetGameInfos.GridSizeX, gameInfo.GetGameInfos.GridSizeY);
    }

    private void OnGameEnd()
    {
        canvas.SetActive(false);
    }

    private void OnPlayQueueChange()
    {
        playQueue++;
        if (playQueue % 2 == 1) Invoke("OpenPlayer1", 1f);
        else Invoke("OpenPlayer2", 1f);
    }

    private void OpenPlayer1()
    {
        player1.IncreaseAlpha();
        player2.ReduceAlpha();
    }

    private void OpenPlayer2()
    {
        player2.IncreaseAlpha();
        player1.ReduceAlpha();
    }
}
