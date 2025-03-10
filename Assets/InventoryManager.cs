using System;
using UnityEngine;
using UnityEngine.UIElements;
public class InventoryManager : MonoBehaviour
{
    [SerializeField] PlayerActions player;
    private Transform[] inventoryHighlight;

    private void Start()
    {
        inventoryHighlight = new Transform[transform.GetChild(0).transform.childCount];
        for (int i = 0; i < transform.GetChild(0).transform.childCount; i++) {
            inventoryHighlight[i] = transform.GetChild(0).transform.GetChild(i);
        }
    }

    private void Update()
    {
        if (Input.GetButtonDown("Hoe")) {
            player.SetActiveAction(PlayerActions.Action.Hoe);
            foreach (var panel in inventoryHighlight) {
                if (panel.transform.name == "Hoe")
                {
                    panel.GetChild(0).gameObject.SetActive(true);
                }
                else {
                    panel.GetChild(0).gameObject.SetActive(false);
                }
            }
        }

        if (Input.GetButtonDown("Water"))
        {
            player.SetActiveAction(PlayerActions.Action.Water);
            foreach (var panel in inventoryHighlight)
            {
                if (panel.transform.name == "Water")
                {
                    panel.GetChild(0).gameObject.SetActive(true);
                }
                else
                {
                    panel.GetChild(0).gameObject.SetActive(false);
                }
            }
        }


    }

}
