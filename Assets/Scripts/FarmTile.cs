using UnityEngine;

public class FarmTile : MonoBehaviour
{
    [SerializeField] private Color baseColor, offsetColor;
    [SerializeField] private SpriteRenderer sRenderer;
    [SerializeField] private GameObject highlight;
    [SerializeField] private GameObject watered;
    public void SetColor()
    {
        sRenderer.color = offsetColor;
    }

    private void OnMouseEnter()
    {
        watered.SetActive(true);
    }

    private void OnMouseExit()
    {
        watered.SetActive(false); 
    }

}
