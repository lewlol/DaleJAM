using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGeneration : MonoBehaviour
{
    public Biome[] biomes;
    int activeBiome;

    Tile activeTile;
    public GameObject baseTile;
    public int worldLength;
    public int worldHeight;
    Vector3 spawnPosition;

    public Texture2D noiseTexture;
    public float caveFrequency;
    public float seed;
    void Start()
    {
        seed = Random.Range(-10000, 10000);
        GenerateNoiseTexture();
        GenerateWorld();
    }

    private void GenerateWorld()
    {
        for(int x = -20; x < worldLength; x++)
        {
            for (int y = 0; y < worldHeight; y++)
            {
                //Check y Level
                float currentYlevel = y;
                //Compare to Biome Level (if above minimum and below max)
                if(currentYlevel <= 50)
                {
                    activeBiome = 0;
                }
                if(currentYlevel > 50 && currentYlevel <= 100)
                {
                    activeBiome = 1;
                }
                if(currentYlevel > 100 && currentYlevel <= 150)
                {
                    activeBiome = 2;
                }
                int num = Random.Range(0, 101);
                if(num <= 90)
                {
                    activeTile = biomes[activeBiome].rockTile;
                }
                if(num > 90 && num <= 96)
                {
                    activeTile = biomes[activeBiome].commonOreTiles[0];
                }
                if(num > 96 && num <= 99)
                {
                    activeTile = biomes[activeBiome].rareOreTiles[0];
                }
                if(num > 99 && num <= 100)
                {
                    activeTile = biomes[activeBiome].uniqueOreTiles[0];
                }
                spawnPosition = new Vector3(x, -y, 0);
                SpawnTile();
            }
        }
    }

    public void SpawnTile()
    {
        GameObject newTile = Instantiate(baseTile, spawnPosition, Quaternion.identity);
        newTile.transform.parent = gameObject.transform;
        newTile.name = activeTile.name;
        newTile.GetComponent<SpriteRenderer>().sprite = activeTile.tileSprite;
        newTile.GetComponent<TileDataPlaceholder>().thisTile = activeTile;
        newTile.GetComponent<BoxCollider2D>().usedByComposite = true;
    }

    public void GenerateNoiseTexture()
    {
        noiseTexture = new Texture2D(worldLength, worldHeight);

        for(int x = 0; x < noiseTexture.width; x++)
        {
            for(int y = 0; y < noiseTexture.height; y++)
            {
                float v = Mathf.PerlinNoise(x * caveFrequency, y * caveFrequency);
            }
        }
    }
}
