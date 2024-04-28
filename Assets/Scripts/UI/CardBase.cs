using UnityEngine;
using UnityEngine.UI;

public class CardBase : ButtonBase
{
    [Header("Components")]
    [SerializeField] private Image cardImage;
    [SerializeField] private Button button;
    [SerializeField] private GameObject backSide;
    [SerializeField] private GameObject frontSide;

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
        Destroy(gameObject);
    }

    public override void OnButtonClick()
    {
        base.OnButtonClick();

        if (!canReact) return;
        backSide.SetActive(false);
        frontSide.SetActive(true);
        canReact = false;
    }

    private void OnTrueSelection(int key)
    {
        if (this.key != key) return;
        button.enabled = false;
        canReact = false;
    }

    private void OnFalseSelection()
    {
        if (!canReact) return;

        button.enabled = false;
        backSide.SetActive(false);
        frontSide.SetActive(true);
    }
}
