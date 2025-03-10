using UnityEngine;

public class FarmManager : MonoBehaviour
{
    [SerializeField] private int width, height;
    [SerializeField] private FarmTile tile_prefab;



    private void Start()
    {
        GenerateGrid();
    }
    private void GenerateGrid()
    {
        for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++) { 
                FarmTile tile = Instantiate(tile_prefab, new Vector3(x + 5.50f, y + 0.504f), Quaternion.identity);
                tile.name = $"Tile {x} {y}";
                tile.SetColor();
            }
        }

    }
}
