using UnityEditor;
using UnityEngine;

public class Selling : MonoBehaviour
{
    [SerializeField] GameObject cartIcon;

    private void OnMouseEnter()
    {
        cartIcon.SetActive(true);
    }

    private void OnMouseDown()
    {
        Messenger.Broadcast(GameEvent.SELL_CROP);
    }

    private void OnMouseExit()
    {
        cartIcon.SetActive(false);
    }

}
