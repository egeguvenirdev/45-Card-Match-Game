using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GridSizer : ButtonBase
{
    [Header("Button Values")]
    [SerializeField] private GamePlayInfos gameInfo;
    [SerializeField] private int valueX = 4;
    [SerializeField] private int valueY = 4;

    [Header("Components")]
    [SerializeField] private Image thisHighlighter;
    [SerializeField] private Image otherHighlighter;
    [SerializeField] private TMP_Text thisButtonText;
    [SerializeField] private TMP_Text otherButtonText;
    [SerializeField] private Color32 disabledTextColor;
    [SerializeField] private Color32 selectedButtonColor;

    protected override void Start()
    {
        base.Start();

        if(gameInfo.GetGameInfos.GridSizeX == valueX)
        {
            OnButtonClick();
        }
    }

    public override void OnButtonClick()
    {
        base.OnButtonClick();
        gameInfo.GetGameInfos.GridSizeX = valueX;
        gameInfo.GetGameInfos.GridSizeY = valueY;
        SetThisButton();
        SetOtherButton();
    }

    private void SetThisButton()
    {
        thisHighlighter.color = selectedButtonColor;
        otherButtonText.color = disabledTextColor;
    }

    private void SetOtherButton()
    {
        otherHighlighter.color = Color.white;
        thisButtonText.color = Color.white;
    }
}
