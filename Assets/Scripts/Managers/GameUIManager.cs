using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameUIManager : MonoSingleton<GameUIManager>
{
    [Header("Game Infos")]
    [SerializeField] private GamePlayInfos gameInfo;

    [Header("Components")]
    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject gamePanel;
    [SerializeField] private RoundEndPanel roundPanel;
    [SerializeField] private CardManager cardManager;
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

    private int playQueue = 1;
    private int matchableCardCount;

    private string winnerName;

    public void Init()
    {
        ActionManager.GameStart += OnGameStart;
        ActionManager.GameEnd += OnGameEnd;
        ActionManager.PlayQueueChange += OnPlayQueueChange;
        ActionManager.ReduceCardCount += OnReduceCardCount;
        ActionManager.GivePoints += OnGivePoints;
        currentRound = 1;
    }

    public void DeInit()
    {
        ActionManager.GameStart -= OnGameStart;
        ActionManager.GameEnd -= OnGameEnd;
        ActionManager.PlayQueueChange -= OnPlayQueueChange;
        ActionManager.ReduceCardCount -= OnReduceCardCount;
        ActionManager.GivePoints -= OnGivePoints;
    }

    #region Game Actions
    private void OnGameStart()
    {
        canvas.SetActive(true);
        OnRoundStart();
    }

    private void OnRoundStart()
    {
        gamePanel.SetActive(true);
        roundPanel.DeInit();

        matchableCardCount = (gameInfo.GetGameInfos.GridSizeX * gameInfo.GetGameInfos.GridSizeY) / 2;

        roundText.text = "Round: " + currentRound + " / " + gameInfo.GetGameInfos.RoundCount;
        playerOnePointText.text = "Point: " + playerOnePoint;
        playerOneScoreText.text = "Score: " + playerOneScore;

        playerTwoPointText.text = "Point: " + playerTwoPoint;
        playerTwoScoreText.text = "Score: " + playerTwoScore;

        OpenPlayer1();
        cardManager.Init(gameInfo.GetGameInfos.GridSizeX, gameInfo.GetGameInfos.GridSizeY);
    }

    private void OnRoundEnd()
    {
        playerOnePoint = 0;
        playerOneScore = 0;
        playerTwoPoint = 0;
        playerTwoScore = 0;
        playQueue = 1;
        matchableCardCount = 0;
        currentRound++;

        cardManager.DeInit();
        gamePanel.SetActive(false);

        string winnerName;

        if (playerOnePoint > playerTwoPoint)
        {
            winnerName = "WINNER IS PLAYER 1";
            playerOneScore++;
        }
        else if (playerOnePoint > playerTwoPoint)
        {
            winnerName = "WINNER IS PLAYER 2";
            playerTwoScore++;
        }
        else winnerName = "DRAW";

        if (currentRound <= gameInfo.GetGameInfos.RoundCount) roundPanel.Init(false, winnerName, playerOneScore, playerTwoScore);
        else roundPanel.Init(true, winnerName, playerOneScore, playerTwoScore);
        //canvas.SetActive(false);
    }

    private void OnGameEnd()
    {
        canvas.SetActive(false);
    }
    #endregion

    #region PlayerQueue
    private void OnGivePoints()
    {
        if (playQueue % 2 == 1)
        {
            playerOnePoint++;
            playerOnePointText.text = "Point: " + playerOnePoint;
        }
        else
        {
            playerTwoPoint++;
            playerTwoPointText.text = "Point: " + playerTwoPoint;
        }
    }

    private void OnReduceCardCount()
    {
        matchableCardCount--;

        if (matchableCardCount <= 0)
        {
            OnRoundEnd();
        }
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
    #endregion
}
