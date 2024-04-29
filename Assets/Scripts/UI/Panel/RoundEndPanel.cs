using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RoundEndPanel : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject newGamebutton;
    [SerializeField] private GameObject nextRoundbutton;
    [SerializeField] private GameObject gameoverText;
    [SerializeField] private TMP_Text winnerName;
    [SerializeField] private TMP_Text player1Score;
    [SerializeField] private TMP_Text player2Score;

    public void Init(bool isLastRRound, string winnerName, int playerOneScore, int playerTwoScore)
    {
        panel.SetActive(true);
        this.winnerName.text = winnerName;

        player1Score.text = "Score: " + playerOneScore;
        player2Score.text = "Score: " + playerTwoScore;

        if (isLastRRound)
        {
            newGamebutton.SetActive(true);
            nextRoundbutton.SetActive(false);
            gameoverText.SetActive(true);
            return;
        }

        newGamebutton.SetActive(false);
        nextRoundbutton.SetActive(true);
        gameoverText.SetActive(false);
    }

    public void DeInit()
    {
        panel.SetActive(false);
    }
}
