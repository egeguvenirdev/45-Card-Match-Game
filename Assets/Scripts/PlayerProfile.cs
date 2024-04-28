using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerProfile : MonoBehaviour
{
    [SerializeField] private Image[] images;
    [SerializeField] private TMP_Text[] texts;
    [SerializeField] private float alphaValue;

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
