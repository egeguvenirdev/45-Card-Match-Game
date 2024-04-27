using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RoundTimer : MonoBehaviour
{
    [Header("Button Values")]
    [SerializeField] private GamePlayInfos gameInfo;
    [SerializeField] private TMP_Text thisButtonText;

    private void Start()
    {
        thisButtonText.text = "" + gameInfo.GetGameInfos.Time;
    }

    public void SetValue(int value)
    {
        gameInfo.GetGameInfos.Time = value;
        thisButtonText.text = "" + gameInfo.GetGameInfos.Time;
    }
}
