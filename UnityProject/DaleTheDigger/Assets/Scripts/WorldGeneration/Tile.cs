using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "World Tile")]
public class Tile : ScriptableObject
{
    public string tileName;
    public Sprite tileSprite;
    public TileTypes tileType;

    public int coinWorth;
}
