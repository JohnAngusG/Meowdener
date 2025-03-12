using UnityEngine;

[CreateAssetMenu(fileName = "InventoryTile", menuName = "Scriptable Objects/InventoryTile")]
public class InventoryTile : ScriptableObject
{

    public new string name;
    public Sprite sprite;
    public PlayerActions.Action action;
    public bool isActive;


}
