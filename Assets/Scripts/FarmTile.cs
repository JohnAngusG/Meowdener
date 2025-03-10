using UnityEngine;

public class FarmTile : MonoBehaviour
{
    [SerializeField] private Color baseColor;
    [SerializeField] private SpriteRenderer sRenderer;
    [SerializeField] private GameObject highlight;
    public void SetColor()
    {
        sRenderer.color = baseColor;
    }

    private void OnMouseEnter()
    {
        highlight.SetActive(true);
    }

    private void OnMouseExit()
    {
        highlight.SetActive(false); 
    }

}
