using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class WorldGeneration : MonoBehaviour
{
    public Biome[] biomes;
    int activeBiome;

    Tile activeTile;
    public List<GameObject> tiles;
    public GameObject baseTile;
    public GameObject lootTile;
    public GameObject gemstoneTile;
    int gemSprite;
    public int worldLength;
    public int worldHeight;
    Vector3 spawnPosition;

    public Texture2D noiseTexture;
    public float caveFrequency;
    public float seed;
    public int currentYlevel;
    void Start()
    {
        seed = Random.Range(-10000, 10000);
        GenerateNoiseTexture();
        GenerateMineShaft();
        GenerateWorld();
        GenerateLoot();
        GenerateGemstones();
    }

    private void GenerateMineShaft()
    {
        yLevelCheck();
        for(int i = -20; i < worldLength; i++)
        {
            activeTile = biomes[activeBiome].rockTile;
            spawnPosition = new Vector2(i, 0);
            SpawnTile();
        }
    }
    private void GenerateWorld()
    {
        for(int x = -20; x < worldLength; x++)
        {
            for (int y = 1; y < worldHeight; y++)
            {
                if(noiseTexture.GetPixel(x,y).r < 0.5)
                {
                    currentYlevel = y;
                    yLevelCheck();
                    ChooseBlock();
                    spawnPosition = new Vector3(x, -y, 0);
                    SpawnTile();
                }
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
        tiles.Add(newTile);
    }

    public void GenerateNoiseTexture()
    {
        noiseTexture = new Texture2D(worldLength * 2, worldHeight * 2);

        for(int x = 0; x < noiseTexture.width; x++)
        {
            for(int y = 0; y < noiseTexture.height; y++)
            {
                float v = Mathf.PerlinNoise((x + seed) * caveFrequency, (y + seed) * caveFrequency);
                noiseTexture.SetPixel(x, y, new Color(v, v, v));
            }
        }
        noiseTexture.Apply();
    }

    public void NewDay()
    {
        currentYlevel = 0;
        tiles.Clear();
        seed = Random.Range(-10000, 10000);
        GenerateNoiseTexture();
        GenerateMineShaft();
        GenerateWorld();
        GenerateLoot();
        GenerateGemstones();
    }

    public void yLevelCheck()
    {
        //Compare to Biome Level (if above minimum and below max)
        if (currentYlevel <= 50)
        {
            activeBiome = 0;
        }
        if (currentYlevel > 50 && currentYlevel <= 100)
        {
            activeBiome = 1;
        }
        if (currentYlevel > 100 && currentYlevel <= 150)
        {
            activeBiome = 2;
        }
    }

    public void ChooseBlock()
    {
        int num = Random.Range(0, 101);
        if (num <= 90)
        {
            activeTile = biomes[activeBiome].rockTile;
        }
        if (num > 90 && num <= 96)
        {
            activeTile = biomes[activeBiome].commonOreTiles[0];
        }
        if (num > 96 && num <= 99)
        {
            activeTile = biomes[activeBiome].rareOreTiles[0];
        }
        if (num > 99 && num <= 100)
        {
            activeTile = biomes[activeBiome].uniqueOreTiles[0];
        }
    }

    public void GenerateLoot()
    {
        currentYlevel = 0;

        for (int x = -20; x < worldLength; x++)
        {
            for (int y = 1; y < worldHeight; y++)
            {
                if (noiseTexture.GetPixel(x, y).r > 0.5)
                {
                    currentYlevel = y;
                    yLevelCheck();
                    spawnPosition = new Vector3(x, -y, 0);

                    //Loot Tile
                    if(noiseTexture.GetPixel(x, y + 1).r < 0.5)
                    {
                        int ran = Random.Range(0, 101);
                        if (ran > 95) //5% Chance
                        {
                            GameObject loot = Instantiate(lootTile, spawnPosition, Quaternion.identity);
                            TileDataPlaceholder tt = loot.GetComponent<TileDataPlaceholder>();
                            tt.thisTile = biomes[activeBiome].loot;
                            loot.GetComponent<SpriteRenderer>().sprite = tt.thisTile.tileSprite;
                            tiles.Add(loot);
                        }
                    }
                }
            }
        }
    }

    public void GenerateGemstones()
    {
        currentYlevel = 0;

        for (int x = -20; x < worldLength; x++)
        {
            for (int y = 1; y < worldHeight; y++)
            {
                if (noiseTexture.GetPixel(x, y).r > 0.5)
                {
                    currentYlevel = y;
                    yLevelCheck();
                    spawnPosition = new Vector3(x, -y, 0);

                    //DeterminePossibleSpawn
                    if (noiseTexture.GetPixel(x + 1, y).r < 0.5)
                    {
                        gemSprite = 2; //Right
                        SpawnGem();
                    }
                    else if (noiseTexture.GetPixel(x - 1, y).r < 0.5)
                    {
                        gemSprite = 3; //Left
                        SpawnGem();
                    }
                    else if (noiseTexture.GetPixel(x, y + 1).r < 0.5)
                    {
                        gemSprite = 0; //Normal
                        SpawnGem();
                    }
                    else if (noiseTexture.GetPixel(x, y - 1).r < 0.5)
                    {
                        gemSprite = 1; //Down
                        SpawnGem();
                    }
                }
            }
        }
    }

    public void SpawnGem()
    {
        int spawnChance = Random.Range(0, 101);
        if (spawnChance > 98)
        {    
            GameObject gem = Instantiate(gemstoneTile, spawnPosition, Quaternion.identity);
            TileDataPlaceholder tt = gem.GetComponent<TileDataPlaceholder>();

            int ran = Random.Range(0, biomes[activeBiome].gemstones.Length);
            tt.thisTile = biomes[activeBiome].gemstones[ran];
            gem.GetComponentInChildren<Light2D>().color = tt.thisTile.gemstoneGlow;
            gem.GetComponent<SpriteRenderer>().sprite = tt.thisTile.gemSprite[gemSprite];
            tiles.Add(gem);
        }
    }
}
