using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Biome")]
public class Biome : ScriptableObject
{
    public GameObject stone;
    public GameObject[] commonOres;  
    public GameObject[] RareOres;
    public GameObject[] UniqueOres;


}
