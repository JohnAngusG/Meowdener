using UnityEngine;

public class FarmTile : MonoBehaviour
{
    [SerializeField] private Color baseColor;
    [SerializeField] private SpriteRenderer sRenderer;
    [SerializeField] private GameObject highlight;

    [SerializeField] private Crop wheatPrefab;

    public void SetColor()
    {
        sRenderer.color = baseColor;
    }

    private void OnMouseEnter()
    {
        highlight.SetActive(true);
    }

    private void OnMouseDown()
    {
        Crop childCrop = GetComponentInChildren<Crop>();
        if (childCrop == null) {
            Crop wheat = Instantiate(wheatPrefab, this.transform, worldPositionStays:false);
            wheat.transform.localPosition = Vector2.zero;
            wheat.Plant();
        }
        else
        {
            childCrop.Water();
        }


    }

    private void OnMouseExit()
    {
        highlight.SetActive(false); 
    }

}
