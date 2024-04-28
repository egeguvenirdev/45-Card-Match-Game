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

    public void Init()
    {

        ActionManager.GameStart += OnGameStart;
        ActionManager.GameEnd += OnGameEnd;

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
    }

    private void OnGameStart()
    {
        canvas.SetActive(true);

        cardManager.CreateCards(gameInfo.GetGameInfos.GridSizeX, gameInfo.GetGameInfos.GridSizeY);
    }

    private void OnGameEnd()
    {
        canvas.SetActive(false);
    }

    private void CreateAnimalCards()
    {

    }
}
