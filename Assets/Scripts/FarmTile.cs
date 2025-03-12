using UnityEngine;

public class FarmTile : MonoBehaviour
{
    [SerializeField] private Color baseColor;
    [SerializeField] private SpriteRenderer sRenderer;
    [SerializeField] private GameObject highlight;

    [SerializeField] private Crop wheatPrefab;
    [SerializeField] private Crop eggplantPrefab;
    public PlayerActions playerAction;

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
            Crop newCrop;
            if (playerAction.activeAction == PlayerActions.Action.PlantWheat)
            {
                newCrop = Instantiate(wheatPrefab, this.transform, worldPositionStays: false);
            }
            else if (playerAction.activeAction == PlayerActions.Action.PlantEggplant)
            {
                newCrop = Instantiate(eggplantPrefab, this.transform, worldPositionStays: false);
            }
            else {
                return;
            }

            newCrop.transform.localPosition = Vector2.zero;
            newCrop.Plant();
        }
        else
        {
            if (playerAction.activeAction == PlayerActions.Action.Water) {
                print("Watering crop");
                childCrop.Water();
            }
        }
    }

    private void OnMouseExit()
    {
        highlight.SetActive(false); 
    }

    private void Start()
    {
        playerAction = FindFirstObjectByType<PlayerActions>();
    }

}
