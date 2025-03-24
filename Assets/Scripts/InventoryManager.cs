using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
public class InventoryManager : MonoBehaviour
{
    [SerializeField] PlayerActions player;
    private Transform[] inventoryPanel;
    private Dictionary<int, InventoryTile> inventoryTileTracker;


    private void Start()
    {
        // set up containers
        inventoryTileTracker = new Dictionary<int, InventoryTile>();

        // set up actual ui panels
        inventoryPanel = new Transform[transform.GetChild(0).transform.childCount];
        for (int i = 0; i < transform.GetChild(0).transform.childCount; i++) {
            inventoryPanel[i] = transform.GetChild(0).transform.GetChild(i);
        }
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

        if (Input.GetButtonDown("Fourth"))
        {
            player.SetActiveAction(inventoryTileTracker[3].action);
            SetHighlighting(inventoryTileTracker[3].name);
        }

        if (Input.GetButtonDown("Fifth"))
        {
            player.SetActiveAction(inventoryTileTracker[4].action);
            SetHighlighting(inventoryTileTracker[4].name);
        }

        if (Input.GetButtonDown("Sixth"))
        {
            player.SetActiveAction(inventoryTileTracker[5].action);
            SetHighlighting(inventoryTileTracker[5].name);
        }

        if (Input.GetButtonDown("Seventh"))
        {
            player.SetActiveAction(inventoryTileTracker[6].action);
            SetHighlighting(inventoryTileTracker[6].name);
        }

    }

    // This way i can loop through the tile when wanting to drop an item and quickly find which one is the highlighted one. 
    private void SetHighlighting(String actionName) {

        foreach (var act in inventoryTileTracker)
        {
                if (act.Value.name == actionName)
                {
                    act.Value.isActive = true;
                }
                else
                {
                    act.Value.isActive = false;
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

    private void Awake()
    {
        Messenger<string>.AddListener(GameEvent.PICKUP, OnPickup);
        Messenger<PlayerActions.Action>.AddListener(GameEvent.USE_ITEM, OnUseItem);
    }

    private void OnDestroy()
    {
        Messenger<string>.RemoveListener(GameEvent.PICKUP, OnPickup);
        Messenger<PlayerActions.Action>.RemoveListener(GameEvent.USE_ITEM, OnUseItem);
    }

    private void OnPickup(string objectName)
    {
        InventoryTile tile = Resources.Load<InventoryTile>($"{objectName}");
        tile.count = 1;
        if (inventoryTileTracker.ContainsValue(tile)){
            if (tile.name != "Hoe" && tile.name != "Water" && tile.name != "Axe")
            {
                foreach (var act in inventoryTileTracker) {
                    if (act.Value == tile) {
                        act.Value.count++;
                        inventoryPanel[act.Key].GetChild(1).GetComponent<TextMeshProUGUI>().text = "" + tile.count;
                        break;
                    }
                }
            }
        }
        else {
            for (int i = 0; i < inventoryPanel.Length; i++)
            {
                if (inventoryPanel[i].name == "InventoryTile")
                {
                    //print($"putting {tile.name} @ {i}");
                    inventoryPanel[i].GetComponent<Image>().sprite = tile.sprite;
                    inventoryPanel[i].name = tile.name;
                    inventoryPanel[i].gameObject.SetActive(true);
                    if (inventoryPanel[i].name == "Hoe" || inventoryPanel[i].name == "Water" || inventoryPanel[i].name == "Axe")
                    {
                        inventoryPanel[i].GetChild(1).GetComponent<TextMeshProUGUI>().text = "";
                    }
                    inventoryTileTracker.Add(i, tile);
                    break;
                }
                
            }
        }
    }




    private void OnUseItem(PlayerActions.Action action)
    {
        foreach (var kvp in inventoryTileTracker)
        {
            if (kvp.Value.action == action)
            {
                // Handle item usage
                if (action != PlayerActions.Action.Water && action != PlayerActions.Action.Hoe && action != PlayerActions.Action.Axe)
                {
                    kvp.Value.count--;
                }

                if (kvp.Value.count == 0)
                {
                    inventoryPanel[kvp.Key].name = "InventoryTile";
                    inventoryPanel[kvp.Key].gameObject.SetActive(false);
                    inventoryTileTracker.Remove(kvp.Key);
                    player.SetActiveAction(PlayerActions.Action.Null);
                    break;
                }
                else {
                    inventoryPanel[kvp.Key].GetChild(1).GetComponent<TextMeshProUGUI>().text = "" + kvp.Value.count;
                }
            }
        }
    }


}
