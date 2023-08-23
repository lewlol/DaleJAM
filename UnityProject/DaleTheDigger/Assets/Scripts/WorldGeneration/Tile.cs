using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "World Tile")]
public class Tile : ScriptableObject
{
    public TileNames tileName;
    public Sprite tileSprite;
    public TileTypes tileType;

    public int breakingpower;
    public int coinWorth;
}
