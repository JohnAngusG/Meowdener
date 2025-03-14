using System;
using System.Collections.Generic;
using UnityEngine;
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

    }

    //private void FillInventoryTiles() {
    //    for (int i = 0; i < inventoryTileActions.Length; i++) {
    //        inventoryPanel[i].GetComponent<Image>().sprite = inventoryTileActions[i].sprite;
    //        inventoryPanel[i].name = inventoryTileActions[i].name;
    //        inventoryPanel[i].gameObject.SetActive(true);
    //        inventoryTileTracker.Add(i, inventoryTileActions[i]);
    //    }
    
    //}

    // This way i can loop through the tile when wanting to drop an item and quickly find which one is the highlighted one. 
    // Do changes to the og object affect the one in the dictionary though? reference or value?
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
    }
    private void OnDestroy()
    {
        Messenger<string>.RemoveListener(GameEvent.PICKUP, OnPickup);
    }

    private void OnPickup(string objectName)
    {
        InventoryTile tile = Resources.Load<InventoryTile>($"{objectName}");
        for (int i = 0; i < inventoryPanel.Length; i++)
        {
            print("loop: " + i);
            if (inventoryPanel[i].name =="InventoryTile")
            {
                inventoryPanel[i].GetComponent<Image>().sprite = tile.sprite;
                inventoryPanel[i].name = tile.name;
                inventoryPanel[i].gameObject.SetActive(true);
                inventoryTileTracker.Add(i, tile);
                break;
            }
        }
    }


}
