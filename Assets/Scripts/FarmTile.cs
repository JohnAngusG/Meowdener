using UnityEngine;

public class FarmTile : MonoBehaviour
{
    [SerializeField] private Color baseColor;
    [SerializeField] private SpriteRenderer sRenderer;
    [SerializeField] private GameObject highlight;

    [SerializeField] private Crop wheatPrefab;
    [SerializeField] private Crop eggplantPrefab;
    [SerializeField] private AudioClip plantingSound;
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
                Messenger<PlayerActions.Action>.Broadcast(GameEvent.USE_ITEM, playerAction.activeAction);
                newCrop = Instantiate(wheatPrefab, this.transform, worldPositionStays: false);
                newCrop.gameObject.name = "Wheat";
            }
            else if (playerAction.activeAction == PlayerActions.Action.PlantEggplant)
            {
                Messenger<PlayerActions.Action>.Broadcast(GameEvent.USE_ITEM, playerAction.activeAction);
                newCrop = Instantiate(eggplantPrefab, this.transform, worldPositionStays: false);
                newCrop.gameObject.name = "Eggplant";
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
                childCrop.Water();
            }

            if (playerAction.activeAction == PlayerActions.Action.Axe && childCrop.GetWaterLevel() == 3) {
                Messenger<FarmTile>.Broadcast(GameEvent.SPAWN_SEED, this);
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
