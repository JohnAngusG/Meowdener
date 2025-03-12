using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventoryManager : MonoBehaviour
{
    [SerializeField] PlayerActions player;
    private Transform[] inventoryPanel;
    [SerializeField] private InventoryTile[] inventoryTileActions;
    private Dictionary<int, InventoryTile> inventoryTileTracker;


    private void Start()
    {
        inventoryTileTracker = new Dictionary<int, InventoryTile>();
        inventoryPanel = new Transform[transform.GetChild(0).transform.childCount];
        for (int i = 0; i < transform.GetChild(0).transform.childCount; i++) {
            inventoryPanel[i] = transform.GetChild(0).transform.GetChild(i);
        }
        FillInventoryTiles();
    }

    private void Update()
    {
        if (Input.GetButtonDown("First")) {
            player.SetActiveAction(inventoryTileTracker[0].action);
            SetHighlighting(inventoryTileTracker[0].name);
        }

        if (Input.GetButtonDown("Second"))
        {
            player.SetActiveAction(inventoryTileTracker[1].action);
            SetHighlighting(inventoryTileTracker[1].name);
        }

        if (Input.GetButtonDown("Third"))
        {
            player.SetActiveAction(inventoryTileTracker[2].action);
            SetHighlighting(inventoryTileTracker[2].name);
        }

    }

    private void FillInventoryTiles() {
        for (int i = 0; i < inventoryTileActions.Length; i++) {
            inventoryPanel[i].GetComponent<Image>().sprite = inventoryTileActions[i].sprite;
            inventoryPanel[i].name = inventoryTileActions[i].name;
            inventoryPanel[i].gameObject.SetActive(true);
            inventoryTileTracker.Add(i, inventoryTileActions[i]);
        }
    
    }

    // This way i can loop through the tile when wanting to drop an item and quickly find which one is the highlighted one. 
    // Do changes to the og object affect the one in the dictionary though? reference or value?
    private void SetHighlighting(String actionName) {
        foreach (var act in inventoryTileActions) {
            if (act.name == actionName)
            {
                act.isActive = true;
            }
            else { 
                act.isActive = false;
            }
        }

        foreach (var panel in inventoryPanel)
        {
            if (panel.transform.name == actionName)
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
