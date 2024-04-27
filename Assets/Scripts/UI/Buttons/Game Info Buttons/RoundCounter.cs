using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RoundCounter : MonoBehaviour
{
    [Header("Button Values")]
    [SerializeField] private GamePlayInfos gameInfo;
    [SerializeField] private TMP_Text thisButtonText;

    private void Start()
    {
        thisButtonText.text = "" + gameInfo.GetGameInfos.RoundCount;
    }

    public void SetValue(int value)
    {
        gameInfo.GetGameInfos.RoundCount = value;
        thisButtonText.text = "" + gameInfo.GetGameInfos.RoundCount;
    }
}
