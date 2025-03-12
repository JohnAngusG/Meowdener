using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    [SerializeField] private Animator anim;
    public enum Action {Hoe, Water, PlantWheat, PlantEggplant};
    public Action activeAction;

    // Update is called once per frame
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
}
