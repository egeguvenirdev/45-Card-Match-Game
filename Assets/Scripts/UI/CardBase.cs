using UnityEngine;
using UnityEngine.UI;

public class CardBase : MonoBehaviour
{
    [SerializeField] private Image cardImage;
    private int key;

    public int Key { get => key; private set => key = value; }

    public void Init(Sprite refImage, int refKey)
    {
        cardImage.sprite = refImage;
        Key = refKey;
    }

    public void DeInit()
    {
        Destroy(gameObject);
    }
}
