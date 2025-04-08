using System.Collections;
using UnityEngine;

public class Crop : MonoBehaviour
{
    [SerializeField] Sprite[] sprites;
    [SerializeField] SpriteRenderer spriteRenderer;
    private int waterLevel = 0;

    public void Plant()
    {
        spriteRenderer.sprite = sprites[waterLevel];
    }

    public void Water() {
        if (waterLevel < sprites.Length - 1) {
            waterLevel++;
            spriteRenderer.sprite = sprites[waterLevel];
        }
    }

    public int GetWaterLevel() {
        return waterLevel;    
    }


}
