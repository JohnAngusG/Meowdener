using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private AudioClip sellSound;
    private AudioSource audioSrc;

    public enum Action {Hoe, Water, PlantWheat, PlantEggplant, Null, Axe, SellWheat, SellEggplant};
    public Action activeAction;

    private void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }


    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {       
            Vector3 mousePosition = Input.mousePosition;
            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
           
            // Hoeing
            if (activeAction == Action.Hoe) {
                if (transform.position.y > mouseWorldPosition.y)
                {
                    anim.SetTrigger("PlowToward");
                }
                else
                {
                    anim.SetTrigger("PlowAway");
                }

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
            audioSrc.PlayOneShot(sellSound);
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
