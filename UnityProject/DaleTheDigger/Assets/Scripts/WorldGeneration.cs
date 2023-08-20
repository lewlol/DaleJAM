using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGeneration : MonoBehaviour
{
    public Biome underground;
    public Biome caverns;
    public Biome theDeep;
    Biome activeBiome;

    public GameObject stone;
    public GameObject[] ores;
    public int worldLength;
    public int worldHeight;
    int currentTile;
    Vector3 spawnPosition;
    void Start()
    {
        GenerateWorld();
    }

    private void GenerateWorld()
    {
        for(int x = -10; x < worldLength; x++)
        {
            for (int y = 0; y < worldHeight; y++)
            {
                //Check y Level
                //Compare to Biome Level (if above minimum and below max)

                spawnPosition = new Vector3(x, -y, 0);
            }
        }
    }

    public void SpawnTile()
    {
        GameObject newTile = Instantiate(activeBiome.stone, spawnPosition, Quaternion.identity);
        newTile.transform.parent = gameObject.transform;
        newTile.name = "World Tile " + currentTile;
        currentTile++;
    }
}
