using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CardBase : ButtonBase
{
    [Header("Components")]
    [SerializeField] private Image cardImage;
    [SerializeField] private Button button;
    [SerializeField] private GameObject backSide;
    [SerializeField] private Image[] frontSide;
    [SerializeField] private GameObject frontSideParent;

    private bool canReact;
    private int key;

    public int Key { get => key; private set => key = value; }

    public void Init(Sprite refImage, int refKey)
    {
        ActionManager.TrueSelection += OnTrueSelection;
        ActionManager.FalseSelection += OnFalseSelection;
        canReact = true;
        cardImage.sprite = refImage;
        Key = refKey;
    }

    public void DeInit()
    {
        ActionManager.TrueSelection -= OnTrueSelection;
        ActionManager.FalseSelection -= OnFalseSelection;
        //Destroy(gameObject);
    }

    public override void OnButtonClick()
    {
        base.OnButtonClick();

        if (!canReact) return;
        canReact = false;
        backSide.SetActive(false);
        frontSideParent.SetActive(true);

        Color tempColor = frontSide[0].color;
        tempColor.a = 1;
        for (int i = 0; i < frontSide.Length; i++)
        {
            frontSide[i].color = tempColor;
        }

        button.interactable = false;
        ActionManager.CardSelection?.Invoke(this, key);
    }

    private void OnTrueSelection(int key)
    {
        if (this.key != key) return;
        button.interactable = false;
        canReact = false;
    }

    private void OnFalseSelection()
    {
        HideButtons();
        canReact = true;
    }

    private void HideButtons()
    {
        Color tempColor = frontSide[0].color;

        DOTween.ToAlpha(() => tempColor, x => tempColor = x, 0, 1f).OnUpdate(() =>
        {
            for (int i = 0; i < frontSide.Length; i++)
            {
                frontSide[i].color = tempColor;
            }

        }).OnComplete(() =>
        {
            button.interactable = true;
            backSide.SetActive(true);
            frontSideParent.SetActive(false);
        });
    }

    public void ActivateButton()
    {
        if (canReact) button.interactable = true;
    }

    public void DisableButton()
    {
        if (canReact) button.interactable = false;
    }
}
