using UnityEngine;

public class FarmManager : MonoBehaviour
{
    [SerializeField] private int width, height;
    [SerializeField] private FarmTile tile_prefab;
    [SerializeField] private GameObject wheatSeedPrefab;
    [SerializeField] private GameObject eggplantSeedPrefab;



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

    private void Awake()
    {
        Messenger<FarmTile>.AddListener(GameEvent.SPAWN_SEED, OnSpawnSeed);
    }
    private void OnDestroy()
    {
        Messenger<FarmTile>.RemoveListener(GameEvent.SPAWN_SEED, OnSpawnSeed);
    }

    private void OnSpawnSeed(FarmTile tile) {
        Crop childCrop = tile.GetComponentInChildren<Crop>();
        Vector3 spawnPoint = childCrop.transform.position;
        
        if (childCrop.gameObject.name == "Wheat")
        {
            GameObject wheatSeed = Instantiate(wheatSeedPrefab);
            wheatSeed.name = "WheatSeed";
        }
        else {
  
            GameObject eggPlantSeed = Instantiate(eggplantSeedPrefab);
            eggPlantSeed.name = "EggplantSeed";
            
        }
        Destroy(childCrop.gameObject);

    }

    


}
