using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerProfile : MonoBehaviour
{
    [SerializeField] private Image[] images;
    [SerializeField] private TMP_Text[] texts;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text pointText;
    [SerializeField] private float alphaValue;

    private int score = 0;
    private int point = 0;
    private bool isActive;

    public void Init()
    {
        score = 0;
    }

    public void DeInit()
    {

    }

    public void ReduceAlpha()
    {
        for (int i = 0; i < images.Length; i++)
        {
            var tempColor = images[i].color;
            tempColor.a = alphaValue;
            images[i].color = tempColor;
        }

        for (int i = 0; i < texts.Length; i++)
        {
            var tempColor = texts[i].color;
            tempColor.a = alphaValue;
            texts[i].color = tempColor;
        }
    }

    public void IncreaseAlpha()
    {
        isActive = true;

        for (int i = 0; i < images.Length; i++)
        {
            var tempColor = images[i].color;
            tempColor.a = 1;
            images[i].color = tempColor;
        }

        for (int i = 0; i < texts.Length; i++)
        {
            var tempColor = texts[i].color;
            tempColor.a = 1;
            texts[i].color = tempColor;
        }
    }
}
