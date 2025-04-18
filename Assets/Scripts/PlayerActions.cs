using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] Camera mainCam;

    // Audio
    [SerializeField] private AudioClip sellSound;
    [SerializeField] private AudioClip waterSound;
    [SerializeField] private AudioClip axeSound;



    public enum Action {Hoe, Water, PlantWheat, PlantEggplant, Null, Axe, SellWheat, SellEggplant};
    public Action activeAction;

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {       
            Vector3 mousePosition = Input.mousePosition;
            Vector3 mouseViewPortPosition = mainCam.ScreenToViewportPoint(mousePosition);
            float relativeX = mouseViewPortPosition.x - 0.5f;
            float relativeY = mouseViewPortPosition.y - 0.5f;


            anim.SetFloat("MouseX", relativeX);
            anim.SetFloat("MouseY", relativeY);

            if (activeAction == Action.Water) {
                anim.SetTrigger("Water");
                SoundManager.Instance.PlaySfx(waterSound);
            }

            if (activeAction == Action.Axe) {
                anim.SetTrigger("Axe");
                SoundManager.Instance.PlaySfx(axeSound);
            }

            
        }
    }
    public void SetActiveAction(Action action) {
        activeAction = action;
    
    }

    private void OnSellCrop()
    {
        if (activeAction == Action.SellWheat || activeAction == Action.SellEggplant) {
            Messenger<PlayerActions.Action>.Broadcast(GameEvent.USE_ITEM, activeAction);
            SoundManager.Instance.PlaySfx(sellSound);
            Messenger.Broadcast(GameEvent.UPDATE_MONEY);

        }

    }

    private void Awake()
    {
        Messenger.AddListener(GameEvent.SELL_CROP, OnSellCrop);
    }
    private void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.SELL_CROP, OnSellCrop);
    }


}
