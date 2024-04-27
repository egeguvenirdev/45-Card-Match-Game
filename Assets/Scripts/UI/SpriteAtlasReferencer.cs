using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D;

public class SpriteAtlasReferencer : MonoBehaviour
{
    [SerializeField] private SpriteAtlas spriteAtlas;
    [SerializeField] private string spriteName;

    private Image imageComponent;
    void Start()
    {
        imageComponent = GetComponent<Image>();

        Sprite sprite = spriteAtlas.GetSprite(spriteName);

        if (sprite != null)
        {
            imageComponent.sprite = sprite;
        }
    }
}

