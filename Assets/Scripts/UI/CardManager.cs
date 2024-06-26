using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
    [Header("Animal Images")]
    [SerializeField] private List<Sprite> animalImages;
    private List<Sprite> tempImages = new();

    [Header("Card Instantiate Settings")]
    [SerializeField] private GameObject cardObj;
    [SerializeField] private GameObject column;
    [SerializeField] private Transform cloumnParent;

    private List<CardBase> cards = new();
    private List<Transform> rows = new();

    private int tempKey;
    private CardBase tempCard;
    private int selectedCardCount;

    private int roundCount = 1;
    private int trueCardCount = 0;

    public void Init(int valueX, int valueY)
    {
        ActionManager.CardSelection += OnCardSelection;

        CreateCards(valueX, valueY);
    }

    public void DeInit()
    {
        ActionManager.CardSelection -= OnCardSelection;
        selectedCardCount = 0;
        tempCard = null;
        tempKey = 0;
        ClearTheDeck();
    }

    private void CreateCards(int valueX, int valueY)
    {
        FillTempList();

        for (int i = 0; i < valueX; i++)
        {
            rows.Add(Instantiate(column, cloumnParent).transform);

            for (int y = 0; y < valueY; y++)
            {
                cards.Add(Instantiate(cardObj, rows[i]).GetComponent<CardBase>());
            }
        }

        SetImagesForTheCards();
    }

    private void SetImagesForTheCards()
    {
        cards.Shuffle();

        for (int i = 0; i < cards.Count; i += 2)
        {
            int randomImageValue = Random.Range(0, tempImages.Count);
            cards[i].Init(tempImages[randomImageValue], cards[i].GetInstanceID());
            cards[i + 1].Init(tempImages[randomImageValue], cards[i].GetInstanceID());

            tempImages.RemoveAt(randomImageValue);
        }
    }

    private void OnCardSelection(CardBase card, int key)
    {
        selectedCardCount++;

        if (selectedCardCount == 1)
        {
            tempCard = card;
            tempKey = key;
        }

        if (selectedCardCount == 2)
        {
            selectedCardCount = 0;

            if (tempKey == key)
            {
                tempCard.DeInit();
                card.DeInit();
                trueCardCount++;
                ActionManager.TrueSelection?.Invoke(key);
                ActionManager.GivePoints?.Invoke();
            }
            else
            {
                ActionManager.FalseSelection?.Invoke();
                ActionManager.PlayQueueChange?.Invoke();
                DisableTheCards();
                Invoke("ActivateTheCards", 1f);
            }

            tempCard = null;
            tempKey = 0;
        }
    }

    private void ActivateTheCards()
    {
        for (int i = 0; i < cards.Count; i++)
        {
            cards[i].ActivateButton();
        }
    }

    private void DisableTheCards()
    {
        for (int i = 0; i < cards.Count; i++)
        {
            cards[i].DisableButton();
        }
    }

    public void ClearTheDeck()
    {
        for (int i = 0; i < cards.Count; i++)
        {
            cards[i].DestroyCard();
        }

        cards.Clear();

        for (int i = 0; i < rows.Count; i++)
        {
            Destroy(rows[i].gameObject);
        }

        rows.Clear();
    }

    private void FillTempList()
    {
        tempImages.Clear();
        for (int i = 0; i < animalImages.Count; i++)
        {
            tempImages.Add(animalImages[i]);
        }
    }
}
