using UnityEngine;

public class FarmManager : MonoBehaviour
{
    [SerializeField] private int width, height;
    [SerializeField] private FarmTile tile_prefab;
    [SerializeField] private GameObject wheatSeedPrefab;
    [SerializeField] private GameObject eggplantSeedPrefab;
    [SerializeField] private GameObject wheatHarvestedPrefab;
    [SerializeField] private GameObject eggplantHarvestedPrefab;

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


        for (int i = 0; i < Random.Range(1, 3); i++) {
            if (childCrop.gameObject.name == "Wheat")
            {
                GameObject wheatSeed = Instantiate(wheatSeedPrefab, childCrop.gameObject.transform.position, Quaternion.identity);
                Vector3 vec = new Vector3(spawnPoint.x, spawnPoint.y, -1);
                wheatSeed.transform.position = vec;
                wheatSeed.name = "WheatSeed";
            }
            else
            {

                GameObject eggPlantSeed = Instantiate(eggplantSeedPrefab, childCrop.gameObject.transform.position, Quaternion.identity);
                Vector3 vec = new Vector3(spawnPoint.x, spawnPoint.y, -1);
                eggplantSeedPrefab.transform.position = vec;
                eggPlantSeed.name = "EggplantSeed";

            }
        }
        SpawnHarvest(tile);
        Destroy(childCrop.gameObject);

    }

    private void SpawnHarvest(FarmTile tile) {
        Crop childCrop = tile.GetComponentInChildren<Crop>();
        Vector3 spawnPoint = childCrop.transform.position;

        if (childCrop.gameObject.name == "Wheat")
        {
            GameObject wheatHarvested = Instantiate(wheatHarvestedPrefab, childCrop.gameObject.transform.position, Quaternion.identity);
            Vector3 vec = new Vector3(spawnPoint.x, spawnPoint.y, -1);
            wheatHarvested.transform.position = vec;
            wheatHarvested.name = "WheatHarvested";
        }
        else
        {
            GameObject eggplantHarvested = Instantiate(eggplantHarvestedPrefab, childCrop.gameObject.transform.position, Quaternion.identity);
            Vector3 vec = new Vector3(spawnPoint.x, spawnPoint.y, -1);
            eggplantHarvested.transform.position = vec;
            eggplantHarvested.name = "EggplantHarvested";
     
        }
    }
}
