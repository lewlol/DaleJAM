using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGeneration : MonoBehaviour
{
    public GameObject stone;
    public GameObject[] ores;
    public int worldLength;
    public int worldHeight;
    int currentTile;
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
                Vector3 spawnPosition = new Vector3(x, -y, 0);
                GameObject newTile = Instantiate(stone, spawnPosition, Quaternion.identity);
                newTile.transform.parent = gameObject.transform;
                newTile.name = "World Tile " + currentTile;
                currentTile++;
            }
        }
    }
}
