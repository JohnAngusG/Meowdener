using System.Collections;
using UnityEngine;

public class Crop : MonoBehaviour
{
    [SerializeField] Sprite[] sprites;
    [SerializeField] SpriteRenderer spriteRenderer;
    private int waterLevel = 0;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Plant()
    {
        spriteRenderer.sprite = sprites[waterLevel];
    }

    public void Water() {
        while (waterLevel < sprites.Length - 1) {
            waterLevel++;
            spriteRenderer.sprite = sprites[waterLevel];
        }
    }
}
