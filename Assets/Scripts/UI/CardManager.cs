using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
    [Header("Animal Images")]
    [SerializeField] private List<Sprite> animalImages;
    private List<Sprite> tempImages;

    [Header("Card Instantiate Settings")]
    [SerializeField] private GameObject cardObj;
    [SerializeField] private GameObject column;
    [SerializeField] private Transform cloumnParent;

    private List<CardBase> cards = new();
    private List<Transform> rows = new();

    public void CreateCards(int valueX, int valueY)
    {
        tempImages = animalImages;

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
            cards[i].Init(tempImages[randomImageValue], i);
            cards[i + 1].Init(tempImages[randomImageValue], i);

            tempImages.RemoveAt(randomImageValue);
        }
    }
}
