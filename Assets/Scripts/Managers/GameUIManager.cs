using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameUIManager : MonoSingleton<GameUIManager>
{
    [Header("Game Infos")]
    [SerializeField] private GamePlayInfos gameInfo;

    [Header("Components")]
    [SerializeField] private Timer timer;
    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject gamePanel;
    [SerializeField] private RoundEndPanel roundPanel;
    [SerializeField] private CardManager cardManager;
    [SerializeField] private TMP_Text roundText;
    [SerializeField] private TMP_Text timeText;
    [SerializeField] private Image remainingTime;
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
        ActionManager.PlayQueueChange += OnPlayQueueChange;
        ActionManager.GivePoints += OnGivePoints;
        currentRound = 1;

        playerOneScore = 0;
        playerTwoScore = 0;
    }

    public void DeInit()
    {
        ActionManager.GameStart -= OnGameStart;
        ActionManager.PlayQueueChange -= OnPlayQueueChange;
        ActionManager.GivePoints -= OnGivePoints;

        canvas.SetActive(false);
    }

    #region Game Actions
    private void OnGameStart()
    {
        canvas.SetActive(true);
        OnRoundStart();
    }

    public void OnRoundStart()
    {
        gamePanel.SetActive(true);
        roundPanel.DeInit();
        timer.Init(gameInfo.GetGameInfos.Time * 60f);
        matchableCardCount = (gameInfo.GetGameInfos.GridSizeX * gameInfo.GetGameInfos.GridSizeY) / 2;

        roundText.text = "Round: " + currentRound + " / " + gameInfo.GetGameInfos.RoundCount;
        playerOnePointText.text = "Point: " + playerOnePoint;
        playerOneScoreText.text = "Score: " + playerOneScore;

        playerTwoPointText.text = "Point: " + playerTwoPoint;
        playerTwoScoreText.text = "Score: " + playerTwoScore;

        OpenPlayer1();
        cardManager.Init(gameInfo.GetGameInfos.GridSizeX, gameInfo.GetGameInfos.GridSizeY);
    }

    public void OnRoundEnd()
    {
        cardManager.DeInit();
        gamePanel.SetActive(false);
        timer.DeInit();

        string winnerName;

        if (playerOnePoint > playerTwoPoint)
        {
            winnerName = "WINNER IS PLAYER 1";
            playerOneScore++;
        }
        else if (playerOnePoint < playerTwoPoint)
        {
            winnerName = "WINNER IS PLAYER 2";
            playerTwoScore++;
        }
        else winnerName = "DRAW";

        if (currentRound < gameInfo.GetGameInfos.RoundCount) roundPanel.Init(false, winnerName, playerOneScore, playerTwoScore);
        else roundPanel.Init(true, winnerName, playerOneScore, playerTwoScore);
        //canvas.SetActive(false);

        playerOnePoint = 0;
        playerTwoPoint = 0;
        playQueue = 1;
        matchableCardCount = 0;
        currentRound++;
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


    public void TimerText(string time, float currentTime)
    {
        timeText.text = "Time: " + time;
        //Debug.Log(currentTime + " / " + gameInfo.GetGameInfos.Time * 60f + " / " + currentTime / ((float)gameInfo.GetGameInfos.Time * 60f));
        remainingTime.fillAmount = currentTime / (gameInfo.GetGameInfos.Time * 60f);
    }
    #endregion
}
